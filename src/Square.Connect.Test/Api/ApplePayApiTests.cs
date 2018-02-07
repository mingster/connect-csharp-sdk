/* 
 * Square Connect API
 *
 * Client library for accessing the Square Connect APIs
 *
 * OpenAPI spec version: 2.0
 * Contact: developers@squareup.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using Square.Connect.Client;
using Square.Connect.Api;
using Square.Connect.Model;

namespace Square.Connect.Test
{
    /// <summary>
    ///  Class for testing ApplePayApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class ApplePayApiTests
    {
        private ApplePayApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new ApplePayApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of ApplePayApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' ApplePayApi
            //Assert.IsInstanceOfType(typeof(ApplePayApi), instance, "instance is a ApplePayApi");
        }

        
        /// <summary>
        /// Test RegisterDomain
        /// </summary>
        [Test]
        public void RegisterDomainTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //RegisterDomainRequest body = null;
            //var response = instance.RegisterDomain(body);
            //Assert.IsInstanceOf<RegisterDomainResponse> (response, "response is RegisterDomainResponse");
        }
        
    }

}