using System.Diagnostics;

namespace mvcapp.Models
{
    public class Complex
    {
        public long ID { get; set; }
        public string Parameters { get; set; }

        public Complex(string parameters)
        {
            Parameters = parameters;
            Process.Start(parameters);
        }
    }
}