using System.Net;

namespace ConsoleBoilerplate.Tests.Helpers
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private string _responseContent;

        public MockHttpMessageHandler(string responseContent)
        {
            _responseContent = responseContent;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(_responseContent)
            });
        }
    }
}
