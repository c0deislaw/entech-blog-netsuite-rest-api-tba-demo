﻿using System;
using System.Text.Json;

using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth;


namespace NetSuiteRestApiTbaDemo.Core
{
    public class NetSuiteApiClient_UsingRestClient
    {
        private static NetSuiteApiConfig _config;
        private static readonly RestClient _restClient;
        
        static NetSuiteApiClient_UsingRestClient()
        {
            _config = new NetSuiteApiConfig();
            _restClient = CreateRestClient();
        }

        private static RestClient CreateRestClient()
        {
            //https://stackoverflow.com/questions/70203289/call-rest-api-using-oauth1-0-to-netsuite-suitetalk-on-c-sharp-application

            var client = new RestClient();
            var oAuth1 = OAuth1Authenticator.ForAccessToken(
                            consumerKey: _config.ClientId,
                            consumerSecret: _config.ClientSecret,
                            token: _config.TokenId,
                            tokenSecret: _config.TokenSecret,
                            OAuthSignatureMethod.HmacSha256);

            oAuth1.Realm = _config.AccountId; 

            client.Authenticator = oAuth1;
            return client;
        }

        public async Task<NsFindIdsResponse> FindCustomerIds()
        {
            var url = _config.ApiRoot;

            var httpRequest = new RestRequest(url, Method.Post);
            var requestBody = new
            {
                firstname = "Company test 5.0",
                lastname = "Test5.0",
                email = "customer5@company.com",
                category = "20"
            };

            httpRequest.AddHeader("Content-Type", "application/json");
            httpRequest.AddJsonBody(requestBody);


            var httpResponse = await _restClient.ExecuteAsync(httpRequest);
            var responseJson = httpResponse.Content;

            var response =
                JsonSerializer.Deserialize<NsFindIdsResponse>(responseJson);
            return response;

        }

        public async Task<NsCustomer> GetCustomer(int customerId)
        {
            var url = _config.ApiRoot + "/customer/" + customerId;


            var httpRequest = new RestRequest(url, Method.Get);

            var httpResponse = await _restClient.ExecuteAsync(httpRequest);
            var responseJson =  httpResponse.Content;

            var customer =
                 JsonSerializer.Deserialize<NsCustomer>(responseJson);

            return customer;
        }
    }
}