// <copyright file="OpenAIControllerTest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace OpenAIAPI.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Converters;
    using NUnit.Framework;
    using OpenAIAPI.Standard;
    using OpenAIAPI.Standard.Controllers;
    using OpenAIAPI.Standard.Exceptions;
    using OpenAIAPI.Standard.Http.Client;
    using OpenAIAPI.Standard.Http.Response;
    using OpenAIAPI.Standard.Utilities;
    using OpenAIAPI.Tests.Helpers;

    /// <summary>
    /// OpenAIControllerTest.
    /// </summary>
    [TestFixture]
    public class OpenAIControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private OpenAIController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.OpenAIController;
        }

        /// <summary>
        /// Lists the currently available (non-finetuned) models, and provides basic information about each one such as the owner and availability..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListEngines()
        {
            // Perform API call
            Standard.Models.ListEnginesResponse result = null;
            try
            {
                result = await this.controller.ListEnginesAsync();
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// Retrieves a model instance, providing basic information about it such as the owner and availability..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestRetrieveEngine()
        {
            // Parameters for the API call
            string engineId = "davinci";

            // Perform API call
            Standard.Models.Engine result = null;
            try
            {
                result = await this.controller.RetrieveEngineAsync(engineId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// Returns a list of files that belong to the user's organization..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListFiles()
        {
            // Perform API call
            Standard.Models.ListFilesResponse result = null;
            try
            {
                result = await this.controller.ListFilesAsync();
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// List your organization's fine-tuning jobs
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListFineTunes()
        {
            // Perform API call
            Standard.Models.ListFineTunesResponse result = null;
            try
            {
                result = await this.controller.ListFineTunesAsync();
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// Gets info about the fine-tune job.
        ///
        ///[Learn more about Fine-tuning](/docs/guides/fine-tuning)
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestRetrieveFineTune()
        {
            // Parameters for the API call
            string fineTuneId = "ft-AF1WoRqd3aJAHsqc9NY7iL8F";

            // Perform API call
            Standard.Models.FineTune result = null;
            try
            {
                result = await this.controller.RetrieveFineTuneAsync(fineTuneId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// Immediately cancel a fine-tune job.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCancelFineTune()
        {
            // Parameters for the API call
            string fineTuneId = "ft-AF1WoRqd3aJAHsqc9NY7iL8F";

            // Perform API call
            Standard.Models.FineTune result = null;
            try
            {
                result = await this.controller.CancelFineTuneAsync(fineTuneId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// Get fine-grained status updates for a fine-tune job.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListFineTuneEvents()
        {
            // Parameters for the API call
            string fineTuneId = "ft-AF1WoRqd3aJAHsqc9NY7iL8F";
            bool? stream = false;

            // Perform API call
            Standard.Models.ListFineTuneEventsResponse result = null;
            try
            {
                result = await this.controller.ListFineTuneEventsAsync(fineTuneId, stream);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// Lists the currently available models, and provides basic information about each one such as the owner and availability..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListModels()
        {
            // Perform API call
            Standard.Models.ListModelsResponse result = null;
            try
            {
                result = await this.controller.ListModelsAsync();
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// Retrieves a model instance, providing basic information about the model such as the owner and permissioning..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestRetrieveModel()
        {
            // Parameters for the API call
            string model = "text-davinci-001";

            // Perform API call
            Standard.Models.Model result = null;
            try
            {
                result = await this.controller.RetrieveModelAsync(model);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// Delete a fine-tuned model. You must have the Owner role in your organization..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestDeleteModel()
        {
            // Parameters for the API call
            string model = "curie:ft-acmeco-2021-03-03-21-44-20";

            // Perform API call
            Standard.Models.DeleteModelResponse result = null;
            try
            {
                result = await this.controller.DeleteModelAsync(model);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }
    }
}