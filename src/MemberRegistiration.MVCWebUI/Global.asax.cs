using FluentValidation.Mvc;
using MemberRegistiration.Business.DependencyResolvers.Ninject;
using MemberRegistiration.Core.Utilities.Infrastructure;
using MemberRegistiration.Core.Validation.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MemberRegistiration.MVCWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));
            FluentValidationModelValidatorProvider.Configure(provider =>
            {
                provider.ValidatorFactory = new NinjectValidationFactory(new ValidationModule());
            });
        }
    }
}
