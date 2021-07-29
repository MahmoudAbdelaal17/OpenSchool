using FluentAssertions;
using OpenSchool.Web.Tests.Acceptance.Brokers;
using System.Threading.Tasks;
using Xunit;

namespace OpenSchool.Web.Tests.Acceptance.Apis.Homes
{
    [Collection(nameof(ApiTestCollection))]
    public class HomeApiTests
    {
        private readonly OpenSchoolApiBroker openSchoolApiBroker;

        public HomeApiTests(OpenSchoolApiBroker openSchoolApiBroker)
        {
            this.openSchoolApiBroker = openSchoolApiBroker;
        }

        [Fact]
        public async Task ShouldReturnHomeMessageAsync()
        {
            //given 
            string expectedMessage = "Hello From Home Controller !";

            //when 
            string actualMessage =
                await this.openSchoolApiBroker.GetHomeMessage();

            //then 
            actualMessage.Should().Be(expectedMessage);
        }
    }

}
