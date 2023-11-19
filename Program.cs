using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graf2
{
    internal class Program
    {
        static public List<bool> SetArrayPos(List<bool> list, int number) {
            List<bool> ret_list = list;
            for (int i = 0; i < list.Count; ++i) {
                if (number == i)
                {
                    ret_list[i] = true;
                }
                else {
                    continue;
                }
                
            }

            return ret_list;
        }


        static bool Passed(List<bool> list) { 
            //returns true if task is passed 
            // false if not passed
            // true by default must not be true at the end
            bool ret = true;
            foreach (bool b in list)
            {
                if (b == false) { 
                    ret = false;
                }
            }
            return ret;
        }


        static void SubMain(List<List<int>> Array)
        {
            Console.WriteLine("Select graph's vertex \nNote that position " +
                "of 0 graph is restrincted");
            int vertex_number = Int32.Parse(Console.ReadLine());

            List<bool> Accesable = new List<bool>();
            List<bool> Pass = new List<bool>();

            //filling with falses
            for (int i = 0; i < Array.Count; ++i) {
                Accesable.Add(false);
                Pass.Add(false);
            }
            


            if (vertex_number > 0 && vertex_number <= Array.Count)
            {
                //set first vertex as passed
                Accesable = SetArrayPos(Accesable, vertex_number - 1);
                int while_counter = 0;
                while (while_counter < Array.Count) {
                    // if we haven't yet found a way to vertex
                    if (Passed(Accesable) != true)
                    {
                        int counter = 0;
                        foreach (var sublists in Array)
                        {
                            // if not passed and could be reached
                            if (Pass[counter] == false && Accesable[counter] == true)
                            {
                                Pass = SetArrayPos(Pass, counter);
                                int element_counter = 0;
                                foreach (var element in sublists)
                                {
                                    if (element == 1)
                                    {
                                        Accesable = SetArrayPos(Accesable, element_counter);
                                    }
                                    element_counter++;
                                }
                            }
                            counter++;
                        }
                    }
                    else {
                        break;
                    }
                    ++while_counter;
                }
                
            }
            // exceptions only 
            else if (vertex_number > Array.Count)
            {
                Console.WriteLine("Are you OK? You require numbers that isn't stated in adjacency matrix." +
                    "\n Change the number of vertex or add some more rows&collumns " +
                    "into adjacency matrix.");
            }
            else
            {
                Console.WriteLine("Wrong vertex number. " +
                    "Plaese try another");
            }

            int print_counter = 1;
            Console.WriteLine(String.Format("--Vertex [{0}] is selected--\n", vertex_number));
            int check = 0;
            foreach (var elem in Accesable)
            {
                if (Pass[print_counter - 1] == true)
                {
                    ++check;
                }
                ++print_counter;
            }
            if (check == 1)
            {
                Pass[vertex_number-1] = true;
            }

            print_counter = 1;
            foreach (var elem in Accesable) {
                if (Pass[print_counter - 1] == false) {
                    ++check;
                    Console.WriteLine(
                        String.Format("Vertex [{0}] is non-achivable", print_counter)
                        );

                }
                
                ++print_counter;
            }
            //достижимость писать тут


        }

        static void Main(string[] args)
        {
            string path = Matrix.GetPath();
            List<List<int>> Array = Matrix.ExtractFromFile(path);
            SubMain(Array);
            Console.WriteLine("\n\n\n\nPress ANY KEY to EXIT");
            Console.ReadKey();
        }
    }
}
