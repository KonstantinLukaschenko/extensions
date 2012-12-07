﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Signum.Entities.Basics;
using Signum.Utilities;
using System.Reflection;
using Signum.Entities;
using Signum.Entities.Alerts;
using Signum.Web.Operations;

namespace Signum.Web.Alerts
{
    public static class AlertClient
    {
        public static string ViewPrefix = "~/Alerts/Views/{0}.cshtml";

        public static void Start(params Type[] tipos)
        {
            if (Navigator.Manager.NotDefined(MethodInfo.GetCurrentMethod()))
            {
                Navigator.RegisterArea(typeof(AlertClient));

                Navigator.AddSettings(new List<EntitySettings>
                {
                    new EntitySettings<AlertDN>(EntityType.Main) { PartialViewName = _ => ViewPrefix.Formato("Alert") },
                    new EntitySettings<AlertTypeDN>(EntityType.String) { PartialViewName = _ => ViewPrefix.Formato("AlertType") },
                });

                WidgetsHelper.GetWidgetsForView += (entity, partialViewName, prefix) =>
                    SupportAlerts(entity, tipos) ? AlertWidgetHelper.CreateWidget(entity as IdentifiableEntity, partialViewName, prefix) :
                    null;

                OperationsClient.AddSettings(new List<OperationSettings>
                {
                     new EntityOperationSettings(AlertaOperations.SaveNew) 
                     { 
                         OnClick = ctx => 
                         {
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
                                 AlertWidgetHelper.JsOnAlertCreated(prevPopupLevel, "Alerta creada correctamente")
                             });
                         }
                     },
                });
            }
        }

        static bool SupportAlerts(ModifiableEntity entity, params Type[] tipos)
        {
            IdentifiableEntity ie = entity as IdentifiableEntity;
            if (ie == null || ie.IsNew)
                return false;

            if (tipos.Contains(ie.GetType()))
                return true;

            return Navigator.IsFindable(typeof(AlertDN));
        }
    }
}