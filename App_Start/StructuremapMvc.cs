using System.Web.Mvc;
using StructureMap;

namespace Epic.App_Start {
    public static class StructuremapMvc {

        public delegate void StructuremapDelegate(IInitializationExpression initExpression);

        public static void Start(StructuremapDelegate callback)
        {
            var container = (IContainer)IoC.Initialize(callback);
            DependencyResolver.SetResolver(new SmDependencyResolver(container));
        }
    }
}