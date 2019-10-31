using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Df.Magalu.Challenge.Infrastructure
{
    public class InjectionContainer : Autofac.Module
    {
        private string assemblyName;

        public InjectionContainer()
        {
            assemblyName = "Df.Magalu.Challenge";
        }

        protected override void Load(ContainerBuilder builder)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var locationSplit = currentAssembly.Location.Split('\\');
            var fullPath = "";
            for (var i = 0; i < locationSplit.Length - 1; i++)
            {
                fullPath += locationSplit[i] + "\\";
            }

            var dlls = System.IO.Directory.GetFiles(fullPath).Where(x => x.Contains(assemblyName) && x.EndsWith(".dll")).ToList();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

            foreach (var dll in dlls)
            {
                AssemblyName name = AssemblyName.GetAssemblyName(dll);

                if (!assemblies.Any(x => x.FullName.Equals(name.FullName)))
                {
                    assemblies.Add(AppDomain.CurrentDomain.Load(name));
                }
            }

            assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

            #region Acl
            var aclList = assemblies.Where(x => x.FullName.Contains(assemblyName)).ToList().Where(type => type.FullName.Contains("Acl"));

            assemblies.Where(x => x.FullName.Contains(assemblyName)).ToList().ForEach(assembly =>
            {
                builder
                    .RegisterAssemblyTypes(assembly)
                    .Where(type => type.FullName.Contains("Acl"))
                    .AsImplementedInterfaces();
            });
            #endregion

            #region Services and DomainServices
            var services = assemblies.Where(x => x.FullName.Contains(assemblyName)).ToList().Where(type => type.FullName.Contains("Service"));

            assemblies.Where(x => x.FullName.Contains(assemblyName)).ToList().ForEach(assembly =>
            {
                builder
                    .RegisterAssemblyTypes(assembly)
                    .Where(type => type.FullName.EndsWith("Service"))
                    .AsImplementedInterfaces();
            });
            #endregion


            #region Factories
            var factories = assemblies.Where(x => x.FullName.Contains(assemblyName)).ToList().Where(type => type.FullName.Contains("Factor"));

            assemblies.Where(x => x.FullName.Contains(assemblyName)).ToList().ForEach(assembly =>
            {
                builder
                    .RegisterAssemblyTypes(assembly)
                    .Where(type => type.FullName.EndsWith("Factor"))
                    .AsImplementedInterfaces();
            });
            #endregion

        }
    }
}
