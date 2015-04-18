using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sc2lottery
{
    class Crafter 
    {

        public List<Recipe> Recipes { get; set; }
        Dictionary<Item, int> itemPool;
        Dictionary<Item, int> cheapest;

        QuickDictionary<Item> id;

        public Crafter()
        {
            id = new QuickDictionary<Item>();

            itemPool = new Dictionary<Item, int>();
            cheapest = new Dictionary<Item, int>();
            Recipes = new List<Recipe>();

            

        }

        public void Craft(List<Item> items)
        {
            foreach (var ii in items)
            {
                Craft(ii);
            }
        }

        public void Make(Item i)
        {
            Craft(i);
            itemPool[i]--;
            if (itemPool[i] <= 0)
                itemPool.Remove(i);
            indent = 0;
            PrintItemPool();
            PrintCheapest();
        }

        public void Make(Item i, int number)
        {
            for (int j = 0; j < number; j++)
            {
                Make(i);
            }
            cheapest.Clear();
        }

        public void Make(List<Item> ii)
        {
            foreach (var i in ii)
            {
                Make(i);
            }
        }


        public void Craft(Item i)
        {

            var r = FindRecipe(i);
            if (r == null)
            {
                if (!itemPool.Keys.Contains(i))
                    itemPool.Add(i, 1);
                else
                    itemPool[i]++;

                if (!cheapest.Keys.Contains(i))
                    cheapest.Add(i, 1);
                else
                    cheapest[i]++;
                return;
            }

            if (itemPool.ContainsKey(i) && itemPool[i] > 0)
            {
                return;
            }



            foreach (var ing in r.Input.Keys)
            {
                for (int j = 0; j < r.Input[ing]; j++)
                {
                    Craft(ing);
                }
            }

            foreach (var ing in r.Input.Keys)
            {
                for (int k = 0; k < r.Input[ing]; k++)
                {
                    itemPool[ing]--;
                    if (itemPool[ing] < 0)
                    {
                        Craft(ing);
                    }
                }

                if (itemPool[ing] <= 0)
                    itemPool.Remove(ing);
            }

            foreach (var item in r.Output.Keys)
            {
                if (!itemPool.ContainsKey(item))
                    itemPool.Add(item, r.Output[item]);
                else
                {
                    itemPool[item] = r.Output[item];
                }
            }

            for (int y = 0; y < indent; y++)
            {
                Console.Write(" ");
            }


            r.Print();
            Console.WriteLine();
            //indent++;
        }

        static int indent = 0;

        public void PrintItemPool()
        {
            Console.Write("(Itempool: ");
            for (int i = 0; i < itemPool.Keys.Count; i++)
            {
                Console.Write(itemPool[itemPool.Keys.ElementAt(i)] + " " + itemPool.Keys.ElementAt(i).Name);
                if (i < itemPool.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(")");
        }

        public void PrintCheapest()
        {
            Console.Write("(Basic Units: ");
            for (int i = 0; i < cheapest.Keys.Count; i++)
            {
                Console.Write(cheapest[cheapest.Keys.ElementAt(i)] + " " + cheapest.Keys.ElementAt(i).Name);
                if (i < cheapest.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(")");
        }

        private Recipe FindRecipe(Item i)
        {
            return Recipes.Where((r) => r.Output.ContainsKey(i)).FirstOrDefault();
        }


    }
}
