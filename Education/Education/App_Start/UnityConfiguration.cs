using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Education.Implementation;
using Unity.Mvc4;

namespace Education
{
    public class UnityConfiguration
    {
        public static void ConfigureIoCContainer()
        {
            IUnityContainer container = new UnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            RegisterTypes(container);
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IEducationRepository, EducationRepository>(new TransientLifetimeManager());
        }
    }
}