namespace Contracts
{
    public class BasicConfiguration
    {
        public Mongo Mongo { get; set; }
        
        public string CalculationServiceUrl { get; set; }
    }

    public class Mongo
    {
        public string Url { get; set; }
        public string Database { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}