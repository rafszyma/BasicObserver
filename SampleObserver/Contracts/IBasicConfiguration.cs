namespace Contracts
{
    public interface IBasicConfiguration
    {
        string MongoUrl { get; set; }

        string CalculationServiceUrl { get; set; }
    }
}