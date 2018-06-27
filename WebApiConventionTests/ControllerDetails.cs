using System;
using System.Reflection;

namespace WebApiConventionTests
{
    public class ControllerDetails
    {
        public Type Controller { get; set; }
        public MethodInfo Action { get; set; }

        private string DebuggerDisplay => $"{Controller.Name}.{Action.Name}";
    }
}