using Newtonsoft.Json;

namespace EmployerPortal.Core.Models
{
    public class Error
    {
        // to handle global exception handling
        public int StatusCode { get; set; } 
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
