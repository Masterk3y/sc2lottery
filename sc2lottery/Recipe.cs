using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sc2lottery
{
    class Recipe
    {
        Dictionary<Item, int> input;
        Dictionary<Item, int> output;

        public String Notes { get; set; }

        public Dictionary<Item, int> Input { get { return input; } set { input = value; } }
        public Dictionary<Item, int> Output { get { return output; } set { output = value; } }

        public Recipe()
        {
            input = new Dictionary<Item, int>();
            output = new Dictionary<Item, int>();
            Notes = "";
        }

        public void Print()
        {
            for (int i = 0; i < Input.Count; i++)
            {
                Console.Write(Input.ElementAt(i).Value + " " + Input.ElementAt(i).Key.Name);
                if (i < Input.Count - 1)
                {
                    Console.Write(" + ");
                }
            }
            Console.Write(" --> ");
            for (int i = 0; i < Output.Count; i++)
            {
                Console.Write(Output.ElementAt(i).Value + " " + Output.ElementAt(i).Key.Name);
                if (i < Output.Count - 1)
                {
                    Console.Write(" + ");
                }
            }
            if (Notes != String.Empty)
                Console.Write(" (" + Notes + ")");
            Console.WriteLine();
        }

        /*
        public void PrintOld()
        {

            for (int i = 0; i < Input.Count; i++)
            {
                Console.Write(Input.ElementAt(i).Name);
                if (i < Input.Count - 1)
                {
                    Console.Write(" + ");
                }

            }
            Console.Write(" --> ");
            for (int i = 0; i < Output.Count; i++)
            {
                Console.Write(Output.ElementAt(i).Name);
                if (i < Output.Count - 1)
                {
                    Console.Write(" + ");
                }

            }
            if(Notes != String.Empty)
                Console.Write("\t\t(" + Notes + ")");
            Console.WriteLine();
        }
        */

    }
}
