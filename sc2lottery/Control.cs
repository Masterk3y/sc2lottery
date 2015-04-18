using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sc2lottery
{
    class Control
    {
        static List<Recipe> recipes;
        static Dictionary<String, Item> items;
        static Recipe temp;

        public static void Main(String[] args)
        {
            recipes = new List<Recipe>();
            items = new Dictionary<String, Item>();

            ReadRecipes();

            Maker m = new Maker() { Recipes = recipes };
            Loop();


        }

        public static void ReadRecipes()
        {
            try
            {
            using (StreamReader r = new StreamReader("recipes.txt"))
            {
                while (!r.EndOfStream)
                {
                    String t = r.ReadLine();

                    //ignore bad lines
                    if (t.Length < 10 || String.IsNullOrWhiteSpace(t) || t.ToUpper() == t)
                    {
                        continue;
                    }

                    String[] parts = t.Split(':');
                    String[] inp = parts[0].Split(',').Select((s) => s.Trim()).ToArray();
                    String[] outp = parts[1].Split(',').Select((s) => s.Trim()).ToArray();

                    temp = new Recipe();

                    foreach (var s in inp)
                    {
                        ProcessInput(s);
                    }

                    foreach (var s in outp)
                    {
                        ProcessOutput(s);
                    }

                    if (parts.Length >= 3)
                    {
                        temp.Notes = parts[2].Trim();
                    }

                    recipes.Add(temp);
                }
            }

            }
            catch (Exception e)
            {
                Console.WriteLine("No data found!\n\n" + e.StackTrace);
            }
        }

        public static void Loop()
        {
            Maker crafter = new Maker() { Recipes = recipes };


            String ss = "";
            do
            {
                ss = Console.ReadLine();



                int c = 0;
                if (String.IsNullOrWhiteSpace(ss))
                {

                }
                else if (items.Keys.Where((s) => s.ToUpper() == ss.ToUpper()).FirstOrDefault() != null)
                {
                    var x = items[items.Keys.Where((s) => s.ToUpper() == ss.ToUpper()).First()];
                    crafter.Craft(x, 1);
                }
                else if (int.TryParse(ss.Substring(0, 2), out c))
                {
                    crafter.Craft(items[ss.Substring(2)], c);
                }
                else if (ss == "list")
                {
                    foreach (var r in recipes)
                    {
                        r.Print();
                    }
                }

            } while (ss != "exit");

        }

        public static void ProcessInput(String s)
        {

            int count = 0;
            if (int.TryParse(s.Substring(0, 2), out count))
            {
                String n = s.Substring(2);
                if (!items.ContainsKey(n))
                {
                    items.Add(n, new Item() { Name = n });
                }
                temp.Input.Add(items[n], count);
            }
            else
            {
                if (!items.ContainsKey(s))
                {
                    items.Add(s, new Item() { Name = s });
                }
                temp.Input.Add(items[s], 1);
            }
        }

        public static void ProcessOutput(String s)
        {

            int count = 0;
            if (int.TryParse(s.Substring(0, 2), out count))
            {
                String n = s.Substring(2);
                if (!items.ContainsKey(n))
                {
                    items.Add(n, new Item() { Name = n });
                }
                temp.Output.Add(items[n], count);
            }
            else
            {
                if (!items.ContainsKey(s))
                {
                    items.Add(s, new Item() { Name = s });
                }
                temp.Output.Add(items[s], 1);
            }
        }

    }
}
