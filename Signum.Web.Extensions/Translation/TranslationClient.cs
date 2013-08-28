﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Signum.Engine.Authorization;
using Signum.Entities.Translation;
using Signum.Utilities;
using Signum.Web.Omnibox;
using Signum.Web.Translation.Controllers;

namespace Signum.Web.Translation
{
    public class TranslationClient
    {
        public static string ViewPrefix = "~/Translation/Views/{0}.cshtml";

        public static ITranslator Translator; 


        /// <param name="copyTranslationsToRootFolder">avoids Web Application restart when translations change</param>
        public static void Start(ITranslator translator, bool instanceTranslator, bool copyNewTranslationsToRootFolder = true)
        {
            if (Navigator.Manager.NotDefined(MethodInfo.GetCurrentMethod()))
            {
                Navigator.RegisterArea(typeof(TranslationClient));
                Navigator.AddSettings(new List<EntitySettings>
                {   
                    new EntitySettings<CultureInfoDN>{ PartialViewName = t=>ViewPrefix.Formato("CultureInfoView")},
                     new EntitySettings<TranslatorDN>{ PartialViewName = t=>ViewPrefix.Formato("Translator")},
                    new EmbeddedEntitySettings<TranslatedCultureDN>{ PartialViewName = t=>ViewPrefix.Formato("Translator")},
                });

                Translator = translator;

                SpecialOmniboxProvider.Register(new SpecialOmniboxAction("TranslateCode",
                    () => TranslationPermission.TranslateCode.IsAuthorized(),
                    uh => uh.Action((TranslationController tc) => tc.Index())));

                if (instanceTranslator)
                {
                    SpecialOmniboxProvider.Register(new SpecialOmniboxAction("TranslateInstances",
                        () => TranslationPermission.TranslateInstances.IsAuthorized(),
                        uh => uh.Action((TranslatedInstanceController tic) => tic.Index())));
                }

                if (copyNewTranslationsToRootFolder)
                {
                    string path = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(new Uri(typeof(DescriptionManager).Assembly.CodeBase).LocalPath)), "Translations");

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    var existingFiles = Directory.GetFiles(path).ToHashSet();

                    foreach (string fromFile in Directory.GetFiles(DescriptionManager.TranslationDirectory))
                    {
                        string toFile = Path.Combine(path, Path.GetFileName(fromFile));

                        if (!existingFiles.Contains(toFile) || File.GetLastWriteTime(toFile) < File.GetLastWriteTime(fromFile))
                        {
                            File.Copy(fromFile, toFile, overwrite: true);
                        }
                    }

                    DescriptionManager.TranslationDirectory = path;
                }
            }
        }
    }
}