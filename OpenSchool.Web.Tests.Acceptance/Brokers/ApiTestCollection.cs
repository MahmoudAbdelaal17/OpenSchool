using Xunit;

namespace OpenSchool.Web.Tests.Acceptance.Brokers
{
    [CollectionDefinition(nameof(ApiTestCollection))]
    public class ApiTestCollection : ICollectionFixture<OpenSchoolApiBroker>
    {}
}
