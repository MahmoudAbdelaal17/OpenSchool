using System.Threading.Tasks;

namespace OpenSchool.Web.Tests.Acceptance.Brokers
{
    public partial class OpenSchoolApiBroker
    {
        private const string HomeRelativeUrl = "api/home";

        public async ValueTask<string> GetHomeMessage() =>
            await this.apiFactoryClient.GetContentStringAsync(HomeRelativeUrl);
        
    }
}
