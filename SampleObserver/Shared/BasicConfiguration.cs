using Contracts;

namespace Shared
{
    public class BasicConfiguration : IBasicConfiguration
    {
        public string MongoUrl { get; set; }
        
        public string CalculationServiceUrl { get; set; }
    }
}