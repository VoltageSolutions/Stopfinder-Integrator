using Moq;
using Moq.Protected;
using System.Net;

namespace StopfinderIntegrator.Infrastructure.UnitTests
{
    public class StopfinderAPITests
    {
        private HttpClient CreateMockHttpClient(Func<HttpRequestMessage, HttpResponseMessage> handlerFunc)
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync((HttpRequestMessage request, CancellationToken token) => handlerFunc(request));

            return new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://testbaseurl.com/")
            };
        }

        [Fact]
        public async Task GetApiBaseUrlAsync_Returns_Trimmed_Url()
        {
            var httpClient = CreateMockHttpClient(req =>
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("https://api.example.com ")
                });
            var api = new StopfinderAPI(httpClient);
            var result = await api.GetApiBaseUrlAsync();
            Assert.Equal("https://api.example.com/", result);
        }

        // Add more tests for AuthenticateAsync, GetApiVersionAsync, GetScheduleAsync as needed
    }
}
