using StructureMap;
using Epic.Data;

namespace Epic
{
    public static class Bootstrapper
    {
        public static void ConfigureDependencies(IInitializationExpression init)
        {
            init.For<IGlobalData>().Use<UnitData>().Named("Unit");
            init.For<IGlobalData>().Use<ArticleData>().Named("Article");
        }
    }
}