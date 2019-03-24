using System.Diagnostics;

namespace mvcapp.Models
{
    public class ComplexConstructor
    {
        public long ID { get; set; }
        public string Parameters { get; set; }

        public ComplexConstructor(string parameters)
        {
            Parameters = parameters;
            Process.Start(parameters);
        }
    }
}