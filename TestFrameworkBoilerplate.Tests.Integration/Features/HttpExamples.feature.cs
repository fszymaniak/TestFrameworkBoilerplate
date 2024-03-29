﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace TestFrameworkBoilerplate.Tests.Integration.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class HttpExamplesFeature : object, Xunit.IClassFixture<HttpExamplesFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "HttpExamples.feature"
#line hidden
        
        public HttpExamplesFeature(HttpExamplesFeature.FixtureData fixtureData, TestFrameworkBoilerplate_Tests_Integration_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "HttpExamples", "Simple Http Examples", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Validate response from getEndpointExample endpoint")]
        [Xunit.TraitAttribute("FeatureTitle", "HttpExamples")]
        [Xunit.TraitAttribute("Description", "Validate response from getEndpointExample endpoint")]
        [Xunit.TraitAttribute("Category", "HttpExample")]
        [Xunit.TraitAttribute("Category", "GetAll")]
        public void ValidateResponseFromGetEndpointExampleEndpoint()
        {
            string[] tagsOfScenario = new string[] {
                    "HttpExample",
                    "GetAll"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate response from getEndpointExample endpoint", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 6
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
        testRunner.Given("the HTTP \'GET\' to the endpoint \'/getEndpointExample\' is being send", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 8
        testRunner.Then("the result match expected json \'ExampleJsons\\\\GetExampleJson.json\' and status cod" +
                        "e \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Validate response from getEndpointExample endpoint with single object")]
        [Xunit.TraitAttribute("FeatureTitle", "HttpExamples")]
        [Xunit.TraitAttribute("Description", "Validate response from getEndpointExample endpoint with single object")]
        [Xunit.TraitAttribute("Category", "HttpExample")]
        [Xunit.TraitAttribute("Category", "GetSingle")]
        public void ValidateResponseFromGetEndpointExampleEndpointWithSingleObject()
        {
            string[] tagsOfScenario = new string[] {
                    "HttpExample",
                    "GetSingle"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate response from getEndpointExample endpoint with single object", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 12
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 13
        testRunner.Given("the HTTP \'GET\' to the endpoint \'/getEndpointExample/136acb7d-b90f-4203-b705-7b9ac" +
                        "e1aba33\' is being send", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 14
        testRunner.Then("the result match expected json \'ExampleJsons\\\\GetSingleExampleJson.json\' and stat" +
                        "us code \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Send request and validate response from postEndpointExample endpoint")]
        [Xunit.TraitAttribute("FeatureTitle", "HttpExamples")]
        [Xunit.TraitAttribute("Description", "Send request and validate response from postEndpointExample endpoint")]
        [Xunit.TraitAttribute("Category", "HttpExample")]
        [Xunit.TraitAttribute("Category", "Post")]
        public void SendRequestAndValidateResponseFromPostEndpointExampleEndpoint()
        {
            string[] tagsOfScenario = new string[] {
                    "HttpExample",
                    "Post"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send request and validate response from postEndpointExample endpoint", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 18
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 19
        testRunner.Given("the HTTP \'POST\' to the endpoint \'/postEndpointExample\' is being send", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 20
        testRunner.Then("the result match expected json \'ExampleJsons\\\\PostExampleResponseJson.json\' and s" +
                        "tatus code \'201\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                HttpExamplesFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                HttpExamplesFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
