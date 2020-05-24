using DMCIT.Web;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DMCIT.Tests.Integration.Web
{
    public class HomeControllerIndexShould : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public HomeControllerIndexShould(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

    }
}
