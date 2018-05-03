using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using DateDiffMVC.App_Start;
using DateDiffMVC.Controllers;
using DateDiffMVC.Services;

namespace DateDiffMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
          //  ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //services
            builder.RegisterType<CalendarService>().As<ICalendarService>().InstancePerRequest();

            builder.RegisterType<LoggerService>().Named<ILoggerService>("handler").InstancePerRequest();
            builder.RegisterDecorator<ILoggerService>((c, inner) => new DecoratorLoggerService(inner), fromKey: "handler");
            //above is placing making our decorator replace our base class.
            //fyi when a ctor needs a parameter (say another service) autofac will come back to dictionary and find the relevant instance,
            //so no need to put in here, but we can if we want and then pass other parameters, see below
            //builder.RegisterDecorator<ILoggerService>(
            //    (c, inner) => new DecoratorLoggerService(inner, c.Resolve<ICacheService>(), 10),
            //    typeof(MembershipRegistrationService).Name).InstancePerRequest();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
