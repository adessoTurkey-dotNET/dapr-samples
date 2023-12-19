using System.Reflection;
using System.Runtime.Loader;
using Adesso.Dapr.Core.Common.Abstraction.Patterns;

namespace Adesso.Dapr.Core.Common.Abstraction.Helpers;

public class AdessoModuleAssemblyDiscovery: SingletonBase<AdessoModuleAssemblyDiscovery>
{
    public Assembly EntryAssembly { get; }

    public IEnumerable<Assembly> AbstractionAssemblies { get; }

    public IEnumerable<Assembly> ApplicationAssemblies { get; }

    public IEnumerable<Assembly> CoreAssemblies { get; }

    public IEnumerable<Assembly> DomainAssemblies { get; }

    public IEnumerable<Assembly> RepositoryAssemblies { get; }

    public IEnumerable<Assembly> ApiAssemblies { get; }

    public IEnumerable<Assembly> SchedulerAssemblies { get; }

    public IEnumerable<Assembly> WorkerAssemblies { get; }


    private AdessoModuleAssemblyDiscovery()
    {
        this.EntryAssembly = Assembly.GetEntryAssembly();

        var path = Path.GetDirectoryName(this.EntryAssembly.Location);
        var moduleAssemblies = Directory
            .GetFiles(path, "Adesso.*.dll", SearchOption.TopDirectoryOnly)
            .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
            .ToList();

        this.AbstractionAssemblies = moduleAssemblies.Where(x => x.FullName.Contains("Abstraction"));
        this.ApplicationAssemblies = moduleAssemblies.Where(x => x.FullName.Contains("Application"));
        this.CoreAssemblies = moduleAssemblies.Where(x => x.FullName.Contains("Core"));
        this.DomainAssemblies = moduleAssemblies.Where(x => x.FullName.Contains("Domain"));
        this.RepositoryAssemblies = moduleAssemblies.Where(x => x.FullName.Contains("Repository"));
        this.ApiAssemblies = moduleAssemblies.Where(x => x.FullName.Contains("Api"));
        this.WorkerAssemblies = moduleAssemblies.Where(x => x.FullName.Contains("Worker"));
        this.SchedulerAssemblies = moduleAssemblies.Where(x => x.FullName.Contains("Scheduler"));
    }
}