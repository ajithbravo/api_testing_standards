using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using Shouldly;
using WebApiTestingStandards.Controllers;

namespace WebApiConventionTests
{
    public class RequiredAttributeChecksTests
    {
        [TestCaseSource(nameof(TestCaseSource))]
        public void RequiredAttributes_CheckForRequiredAttributes_ReportOnFailedChecks(Type complexType)
        {
            complexType.GetPublicProperties()
                .SelectMany(x => x.CustomAttributes)
                .Select(x => x.AttributeType)
                .Any(x => x == typeof(RequiredAttribute))
                .ShouldBeTrue("[RequiredAttribute] are required on at least one API Request Model property");
        }

        private static List<TestCaseData> TestCaseSource()
        {
            return typeof(CustomerController).GetAllComplexTypesUsedInControllerActionParameters()
                .Select(x => new TestCaseData(x)
                {
                    TestName = $"{x.Name}"
                }).ToList();
        }
    }
}