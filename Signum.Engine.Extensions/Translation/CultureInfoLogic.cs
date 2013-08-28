﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Signum.Engine.Maps;
using Signum.Engine.DynamicQuery;
using Signum.Utilities.Reflection;
using Signum.Entities.Basics;
using System.Linq.Expressions;
using System.Globalization;
using Signum.Utilities;
using Signum.Entities.Translation;
using System.Reflection;
using Signum.Engine.Operations;
using Signum.Engine.Authorization;
using Signum.Entities.Authorization;

namespace Signum.Engine.Translation
{
    public static class CultureInfoLogic
    {
        internal static void AssertStarted(SchemaBuilder sb)
        {
            sb.AssertDefined(ReflectionTools.GetMethodInfo(() => CultureInfoLogic.Start(null, null)));
        }

        public static ResetLazy<Dictionary<CultureInfo, CultureInfoDN>> CultureInfoToEntity;

        public static void Start(SchemaBuilder sb, DynamicQueryManager dqm)
        {
            if (sb.NotDefined(MethodInfo.GetCurrentMethod()))
            {
                sb.Include<CultureInfoDN>();

                dqm.RegisterQuery(typeof(CultureInfoDN), () =>
                    from c in Database.Query<CultureInfoDN>()
                    select new
                    {
                        Entity = c,
                        c.Id,
                        c.Name,
                        c.EnglishName,
                        c.NativeName,
                    });

                CultureInfoToEntity = sb.GlobalLazy(() => Database.Query<CultureInfoDN>().ToDictionary(ci => CultureInfo.GetCultureInfo(ci.Name), ci=>ci),
                    invalidateWith: new InvalidateWith(typeof(CultureInfoDN)));

                new Graph<CultureInfoDN>.Execute(CultureInfoOperation.Save)
                {
                    AllowsNew = true,
                    Lite = false,
                    Execute = (ci, _) => { },
                }.Register();

                sb.Schema.Synchronizing += Schema_Synchronizing;

                PermissionAuthLogic.RegisterTypes(typeof(TranslationPermission));
            }
        }

        static SqlPreCommand Schema_Synchronizing(Replacements arg)
        {
            var cis = Database.Query<CultureInfoDN>().ToList();

            var table = Schema.Current.Table(typeof(CultureInfoDN));

            return cis.Select(c => table.UpdateSqlSync(c)).Combine(Spacing.Double);
        }

        public static CultureInfoDN ToCultureInfoDN(this CultureInfo ci)
        {
            return CultureInfoToEntity.Value.GetOrThrow(ci);
        }

        public static IEnumerable<CultureInfo> ApplicationCultures
        {
            get
            {
                return CultureInfoToEntity.Value.Keys;
            }
        }

        public static IEnumerable<T> ForEachCulture<T>(Func<CultureInfoDN, T> func)
        {
            foreach (var c in CultureInfoToEntity.Value)
            {
                using (Sync.ChangeBothCultures(c.Key))
                {
                    yield return func(c.Value);
                }
            }
        }

        public static List<CultureInfo> CultureInfos(string defaultCulture)
        {
            var cultures = CultureInfoLogic.ApplicationCultures;

            TranslatorDN tr = UserDN.Current.Translator();

            if (tr != null)
                cultures = cultures.Where(ci => ci.Name == defaultCulture || tr.Cultures.Any(tc => tc.Culture.CultureInfo == ci));

            return cultures.OrderByDescending(a => a.Name == defaultCulture).ThenBy(a => a.Name).ToList();
        }
    }
}
