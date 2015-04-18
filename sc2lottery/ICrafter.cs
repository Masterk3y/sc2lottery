using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sc2lottery
{
    interface ICrafter
    {
        List<Recipe> Recipes { get; set; }

        void Craft(Item i);
        Recipe FindRecipe(Item i);

    }
}
