using TUZ.Entities;

namespace TUZ.API.Tests
{
    public class DataApiMock : IDataApi
    {
        private readonly ApiDataGenerator _apiDataGenerator;
        
        public DataApiMock(ApiDataGenerator apiDataGenerator)
        {
            _apiDataGenerator = apiDataGenerator;
        }
        
        public Train GetData(TripInfo tripInfo)
        {
            return _apiDataGenerator.GenerateTrain();
        }
    }
}