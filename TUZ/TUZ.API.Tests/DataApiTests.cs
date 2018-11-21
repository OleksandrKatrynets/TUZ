using Xunit;

namespace TUZ.API.Tests
{
    public class DataApiTests
    {
        private readonly IDataApi _api;
        
        public DataApiTests()
        {
            _api = new DataApiMock(new ApiDataGenerator());
        }
        
        [Fact]
        public void Test()
        {
            var data = _api.GetData(null);
        }
    }
}