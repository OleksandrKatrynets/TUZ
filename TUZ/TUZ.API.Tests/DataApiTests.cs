using Xunit;

namespace TUZ.API.Tests
{
    public class DataApiTests
    {
        private readonly DataApiMock _mock;
        
        public DataApiTests()
        {
            _mock = new DataApiMock(new ApiDataGenerator());
        }
        
        [Fact]
        public void Test()
        {
            var data = _mock.GetData(null);
        }
    }
}