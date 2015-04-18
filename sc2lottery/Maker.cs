using System;
using System.Collections;
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
        CraftJobs<Recipe> craftJobs;
        int priority;

        public Maker()
        {
            currentItems = new QuickDictionary<Item>();
            craftJobs = new CraftJobs<Recipe>();
        }

        public void Craft(Item i)
        {
            Craft(i, 1);
        }

        public void Craft(Item i, int amount)
        {
            priority = 0;
            CollectCraftJobs(i, amount);

            var x = craftJobs.OrderBy((pair) => pair.Value[1]).Reverse().ToList();
            int max = x.First().Value[1];
            Console.WriteLine(max);
            foreach (var item in x)
            {
                for (int j = 0; j < max - item.Value[1]; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(item.Value[0] + "x: " + item.Key.ToString());
            }
            if (currentItems.Count > 0)
                Console.WriteLine("Units Left: " + currentItems.ToString());
            craftJobs.Clear();
        }

        private void CollectCraftJobs(Item i, int amount)
        {


            var r = FindRecipe(i);
            if (r == null)
            {
                priority--;
                return;
            }

            if (currentItems[i] >= amount)
            {
                currentItems[i] -= amount;
                priority--;
                return;
            }

            int times = (int)Math.Ceiling((double)amount / r.Output[i]);
            if (r.Output[i] > amount)
            {
                currentItems[i] += (r.Output[i] - amount);
            }
            if (craftJobs.Contains(r))
            {
                craftJobs[r, 0] += times;
                // priority--;
            }
            else
            {
                craftJobs.Add(r, times, priority);
            }

            foreach (var input in r.Input)
            {
                priority++;
                CollectCraftJobs(input.Key, input.Value * amount);
            }
            priority--;
        }

        public Recipe FindRecipe(Item i) { return Recipes.Where((r) => r.Output.ContainsKey(i)).FirstOrDefault(); }


    }
}
