using NSubstitute;

namespace ConsoleBoilerplate.Tests.Helpers
{
    public class HttpTestHelper
    {
        public static IHttpClientFactory HttpClientFactory(string response)
        {
            var httpClientFactory = Substitute.For<IHttpClientFactory>();
            var httpClient = new HttpClient(new MockHttpMessageHandler("{}"));
            httpClientFactory.CreateClient(Arg.Any<string>()).Returns(httpClient);

            return httpClientFactory;
        }
    }
}
