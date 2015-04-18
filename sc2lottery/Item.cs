using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sc2lottery
{
    class Item
    {
        public String Name { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
