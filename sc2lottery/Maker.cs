using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sc2lottery
{
    class Maker
    {

        QuickDictionary<Item> currentItems;
        public List<Recipe> Recipes { get; set; }
        QuickDictionary<Recipe> craftJobs;

        public Maker()
        {
            currentItems = new QuickDictionary<Item>();
            craftJobs = new QuickDictionary<Recipe>();
        }

        public void Craft(Item i, int amount)
        {
            Console.WriteLine(i.Name);
            CollectCraftJobs(i, amount);
            foreach (var item in craftJobs)
            {
                Console.WriteLine(item.Value + "x: " + item.Key.ToString());
            }


        }

        private void CollectCraftJobs(Item i, int amount)
        {
            var r = FindRecipe(i);
            if (r == null)
            {
                return;
            }

            if (currentItems[i] >= amount)
            {
                currentItems[i] -= amount;
                return;
            }

            int times = (int)Math.Ceiling((double)amount / r.Output[i]);
            if (r.Output[i] > amount)
            {
                currentItems[i] += (r.Output[i] - amount);
            }
            if (craftJobs.Contains(r))
            {
                craftJobs[r] += times;
            }
            else
                craftJobs.Add(r, times);

            foreach (var input in r.Input)
            {
                CollectCraftJobs(input.Key, input.Value * amount);
            }


        }

        public Recipe FindRecipe(Item i) { return Recipes.Where((r) => r.Output.ContainsKey(i)).FirstOrDefault(); }


    }
}
