using System.Web.Mvc;

using GoodWatchHunting.MVC;
using GoodWatchHunting.MVC.DependencyResolution;

using StructureMap;

[assembly: WebActivator.PreApplicationStartMethod(typeof(StructuremapMvc), "Start")]

namespace GoodWatchHunting.MVC {
    public static class StructuremapMvc {
        public static void Start() {
            var container = (IContainer) IoC.Initialize();
            DependencyResolver.SetResolver(new SmDependencyResolver(container));
        }
    }
}