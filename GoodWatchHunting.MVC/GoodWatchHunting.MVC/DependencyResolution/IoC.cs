using StructureMap;

namespace GoodWatchHunting.MVC.DependencyResolution
{
  public static class IoC
  {
    public static IContainer Initialize()
    {
      ObjectFactory.Initialize(x =>
        {
          x.Scan(scan =>
            {
              scan.WithDefaultConventions();
              scan.AssembliesFromApplicationBaseDirectory();
              scan.ExcludeNamespace("StructureMap");
              scan.LookForRegistries();
            });
          //                x.For<IExample>().Use<Example>();
        });
      return ObjectFactory.Container;
    }
  }
}