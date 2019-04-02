using System.Diagnostics;

namespace mvcapp.ExampleClasses
{
    public class ComplexSetter
    {
        private string _parameters;
        public long ID { get; set; }

        public string Parameters
        {
            get { return _parameters; }
            set
            {
                _parameters = value;
                Process.Start(_parameters);
            }
        }
    }
}

