using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _$PROJECT_NAME$_.Utils
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class DependencyInjectionAttribute : Attribute
    {
        public Type InjectFrom { get; set; }
        public DependencyInjectionScope Scope { get; set; }
        public DependencyInjectionAttribute(Type injectFrom, DependencyInjectionScope scope)
        {
            InjectFrom = injectFrom;
            Scope = scope;
        }

        public static IEnumerable<DependencyInjectionBinding> GetBindingForAssembly(Assembly assembly)
        {
            return assembly.GetTypes()
                .SelectMany(type =>
                {
                    return type.GetCustomAttributes(typeof(DependencyInjectionAttribute), true)
                        .Cast<DependencyInjectionAttribute>()
                        .Select(attr => new DependencyInjectionBinding
                        {
                            Destination = type,
                            Source = attr.InjectFrom,
                            Scope = attr.Scope
                        });
                });
        }
    }

    public class DependencyInjectionBinding
    {
        public Type Source { get; set; }
        public Type Destination { get; set; }
        public DependencyInjectionScope Scope { get; set; }
    }

    public enum DependencyInjectionScope
    {
        Transient,
        Scoped,
        Singleton
    }
}
