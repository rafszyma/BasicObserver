
namespace Contracts.Models
{
    public class TimeSeriesModel
    {
        public string Tenant { get; set; }
        public long T { get; set; }
        
        public double V { get; set; }
    }
}