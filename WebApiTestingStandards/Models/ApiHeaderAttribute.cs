using System;
using System.Web.Http.Filters;

namespace WebApiTestingStandards.Models
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ApiHeaderAttribute : FilterAttribute
    {
        private string Description { get; }
        private string Name { get; }
        private bool Required { get; }
        private Type Type { get; }

        public ApiHeaderAttribute(Type type, string name, string description, bool required)
        {
            Type = type;
            Name = name;
            Description = description;
            Required = required;
        }
    }
}