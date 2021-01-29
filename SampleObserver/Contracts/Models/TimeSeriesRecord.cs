
namespace Contracts.Models
{
    public class TimeSeriesRecord
    {
        public string Tenant { get; set; }
        
        public long T { get; set; }
        
        public double V { get; set; }
    }
}