using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public partial class Unit
    {
        private string meas;
        private string type;

        public Unit(string meas, string type)
        {
            this.meas = meas;
            this.type = type;
        }

        public string MEAS
        {
            get { return meas; }
            set { meas = value; }
        }

        public string TYPE
        {
            get { return type; }
            set { type = value; }
        }
    }
}
