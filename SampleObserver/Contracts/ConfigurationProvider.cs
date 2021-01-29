namespace Contracts
{
    public interface IConfigurationProvider
    {
        string MongoUrl();

        string CalculationServiceUrl();
        
        
    }
}