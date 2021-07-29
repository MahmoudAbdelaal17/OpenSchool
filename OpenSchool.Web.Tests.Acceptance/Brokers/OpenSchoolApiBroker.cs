using Microsoft.AspNetCore.Mvc.Testing;
using OpenSchool.Web.Api;
using RESTFulSense.Clients;
using System.Net.Http; 

namespace OpenSchool.Web.Tests.Acceptance.Brokers
{
    public partial class OpenSchoolApiBroker
    {
        private readonly WebApplicationFactory<Startup> webApplicationFactory;
        private readonly HttpClient httpClient;
        private readonly IRESTFulApiFactoryClient apiFactoryClient;

        public OpenSchoolApiBroker()
        {
            this.webApplicationFactory = new WebApplicationFactory<Startup>();
            this.httpClient = this.webApplicationFactory.CreateClient();
            this.apiFactoryClient = new RESTFulApiFactoryClient(this.httpClient);
        }

    }
}
