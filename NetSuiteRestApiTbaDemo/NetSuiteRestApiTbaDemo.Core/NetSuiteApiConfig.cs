
namespace NetSuiteRestApiTbaDemo.Core
{
    public class NetSuiteApiConfig : IApiConfig
    {
        public string AccountId { get; } = "5261549_SB1";
        
        public string ClientId { get; } = "7877ba8c47c43484534739494884be9244280b87819f75e053ca451b3e84f981";
        public string ClientSecret { get; } = "87be696cf97b9bb5dcace5c0e5cbd007e9cc75710e92d1c58fa88b0c6deb7bc9";

        public string TokenId { get; } = "04a750eb67724d1a973a49a946ed4980c994a9d0690786e235231979ec4479fb";
        public string TokenSecret { get; } = "f9b8d359990f5c5c79ecbff262e33eb711f488cddd99c610da1947647b6d439a";

        public string ApiRoot { get; } = "https://5261549-sb1.suitetalk.api.netsuite.com/services/rest/record/v1/vendor";
    }
}