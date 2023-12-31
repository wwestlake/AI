using FluentResults;
using System.Reflection;

namespace AITesting
{
    public class DataLabel<Tdata, Tlabel> {
        private Tdata _data;
        private Tlabel _label;

        public DataLabel(Tdata data, Tlabel label) 
        {
            _data = data;
            _label = label;
        }

        public Tdata Data => _data;
        public Tlabel Label => _label;
    }


}
