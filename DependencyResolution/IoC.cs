using StructureMap;
using Epic.App_Start;
namespace Epic {
    public static class IoC {
        public static IContainer Initialize(StructuremapMvc.StructuremapDelegate callback)
        {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });

                            callback(x);
                        });
            return ObjectFactory.Container;
        }
    }
}