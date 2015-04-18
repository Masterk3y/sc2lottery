using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sc2lottery
{
    class CraftJob
    {

        public Recipe Recipe { get; set; }
        public int Amount { get; set; }

        public CraftJob(Recipe r)
        {
            Recipe = r;
            Amount = 1;
        }
        public CraftJob(Recipe r, int amount)
        {
            Recipe = r;
            Amount = amount;
        }

    }
}
