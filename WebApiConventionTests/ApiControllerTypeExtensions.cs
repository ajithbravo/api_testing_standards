using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace WebApiConventionTests
{
    public static class ApiControllerTypeExtensions
    {
        public enum IncludePrimativeLikeParametersEnum
        {
            True,
            False
        }

        public static IEnumerable<Type> GetAllComplexTypesUsedInControllerActionParameters(this Type apiControllerType,
            IncludePrimativeLikeParametersEnum includePrimativeLikeParameters =
                IncludePrimativeLikeParametersEnum.False)
        {
            var data = apiControllerType.GetControllerActions()
                .Select(x => x.Action)
                .SelectMany(action => action.GetParameters())
                .Select(x => x.ParameterType)
                .ToList();

            if (includePrimativeLikeParameters == IncludePrimativeLikeParametersEnum.False)
            {
                data = data.Where(x => !x.IsPrimitiveLike()).ToList();
            }

            var nestedComplexTypes = data
                .Where(x => !x.IsPrimitiveLike())
                .SelectMany(x => x.GetNestedComplexTypes())
                .ToList();

            return data.Union(nestedComplexTypes).Distinct().ToList();
        }

        private static IEnumerable<ControllerDetails> GetControllerActions(this Type apiControllerType)
        {
            return apiControllerType.Assembly
                .GetExportedTypes()
                .Where(type => typeof(ApiController).IsAssignableFrom(type))
                .SelectMany(apiController => apiController
                    .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod)
                    .Where(methodInfo => methodInfo.DeclaringType == apiController)
                    .Select(action => new ControllerDetails
                    {
                        Controller = apiController,
                        Action = action
                    })
                ).ToList();
        }
    }
}