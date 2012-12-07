﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Signum.Entities.Basics;
using Signum.Utilities;
using System.Reflection;
using Signum.Entities;
using Signum.Entities.Notes;
using Signum.Web.Operations;

namespace Signum.Web.Notes
{
    public static class NotesClient
    {
        public static string ViewPrefix = "~/Notes/Views/{0}.cshtml";

        public static void Start(params Type[] tipos)
        {
            if (Navigator.Manager.NotDefined(MethodInfo.GetCurrentMethod()))
            {
                Navigator.RegisterArea(typeof(NotesClient));

                Navigator.AddSettings(new List<EntitySettings>
                {
                    new EntitySettings<NoteDN>(EntityType.Main) 
                    { 
                        PartialViewName = _ => ViewPrefix.Formato("Nota"), 
                        IsCreable = EntityWhen.Never 
                    },
                });

                WidgetsHelper.GetWidgetsForView += (entity, partialViewName, prefix) =>
                    SupportsNotes(entity, tipos) ? NoteWidgetHelper.CreateWidget(entity as IdentifiableEntity, partialViewName, prefix) :
                    null;

                OperationsClient.AddSettings(new List<OperationSettings>
                {
                    new EntityOperationSettings(NoteOperation.Save)
                    { 
                        OnClick = ctx => {
                            string prevPopupLevel = ""; //To update notes count
                            if (ctx.Prefix.HasText())
                            {
                                int index = ctx.Prefix.LastIndexOf(TypeContext.Separator);
                                if (index > 0)
                                prevPopupLevel =  ctx.Prefix.Substring(0, ctx.Prefix.LastIndexOf(TypeContext.Separator));
                            }

                            return new JsOperationExecutor(ctx.Options()).validateAndAjax(ctx.Prefix, new JsFunction("prefix")
                            {
                                JsViewNavigator.closePopup(ctx.Prefix),
                                NoteWidgetHelper.JsOnNoteCreated(prevPopupLevel, "Nota creada correctamente")
                            });
                        }
                    }
                });
            }
        }

        static bool SupportsNotes(ModifiableEntity entity, Type[] tipos)
        {
            IdentifiableEntity ie = entity as IdentifiableEntity;
            if (ie == null || ie.IsNew)
                return false;

            if (!tipos.Contains(ie.GetType()))
                return false;

            return Navigator.IsFindable(typeof(NoteDN));
        }
    }
}