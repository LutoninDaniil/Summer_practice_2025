using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
namespace task05
{
    public class ClassAnalyzer
    {
        private readonly Type _type;

        public ClassAnalyzer(Type type)
        {
            _type = type;
        }

        public IEnumerable<string> GetPublicMethods()
        {
            return _type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Select(m => m.Name)
                .ToList();
        }

        public IEnumerable<string> GetMethodParams(string methodname)
        {
            var method = _type.GetMethod(methodname);
            if (method == null) return Enumerable.Empty<string>();

            return method.GetParameters()
                .Select(p => p.Name ?? string.Empty)
                .Where(name => !string.IsNullOrEmpty(name))
                .ToList()!;
        }

        public IEnumerable<string> GetAllFields()
        {
            return _type.GetFields(BindingFlags.Instance |
                                  BindingFlags.Public |
                                  BindingFlags.NonPublic)
                .Select(f => f.Name)
                .OrderBy(name => name)
                .ToList()!;
        }

        public IEnumerable<string> GetProperties()
        {
            return _type.GetProperties()
                .Select(p => p.Name)
                .ToList()!;
        }

        public bool HasAttribute<T>() where T : Attribute
        {
            return _type.GetCustomAttributes(typeof(T), false).Any();
        }
    }
}
