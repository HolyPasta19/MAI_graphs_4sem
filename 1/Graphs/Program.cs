using System;


namespace Graphs 
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            int flag = 0;
            Graph_int? graph=null;
            StreamWriter? sw = null;

            for (int i = 0; i < args.Length; i++)
            {
                for (int j = 0; j < args.Length; j++)
                    if (args[j] == "-h")
                    {
                        ShowHelp();
                        flag = 1;
                        break;
                    }
                if (flag == 1)
                {
                    break;
                }
            }
            for (int i = 0; i<args.Length; i++) 
            {
                if (args[i]=="-m")
                {
                    graph = new GraphMatrix(args[i + 1]);
          

                }
                else if (args[i]=="-e")
                {
                    graph = new List_Edges(args[i+1]);

                }
                else if (args[i]=="-l")
                {
                    graph = new Graph_Adjacency(args[i + 1]); 
                }
                else if (args[i] == "-o")
                {
                    sw = new StreamWriter(args[i+1]);
                    sw.AutoFlush = true;
                }
                
            }
            if (graph==null)
            {
                return;
            }
            if (sw == null)
            {
                sw = new StreamWriter(Console.OpenStandardOutput());
                sw.AutoFlush = true;
                Console.SetOut(sw);
            }
            
            if (graph.IsDirected() == false)
            {
                List<int> vector = new List<int>();
                vector = graph.NotOrientedVector_Degrees();
                sw.Write("Vector of Degrees is: ");
                vector.ArrayOutput(sw);
                sw.WriteLine();

            }
            else
            {
                List<int> vector1 = new List<int>();
                List<int> vector2 = new List<int>();
                vector1 = graph.OrientedVector_Degrees().Item1;
                sw.Write("Vector++ is: ");
                vector1.ArrayOutput(sw);
                sw.WriteLine();
                vector2 = graph.OrientedVector_Degrees().Item2;
                sw.Write("Vector-- is: ");
                vector2.ArrayOutput(sw);
                sw.WriteLine();
            }
            
            var distance = graph.Floyd_Warshal();
            
            sw.WriteLine("Distance is: ");
            distance.Matrix_output(sw);
            var extr = Vector_Degrees.Excentr(distance);
            if (extr.Count == 0)
            {
                return;
            }
            sw.WriteLine("Excentricity is: ");
            extr.ArrayOutput(sw);
            if (graph.IsDirected() == true)
            {
                return;
            }
            var radius = Vector_Degrees.GetRadius(extr);
            sw.WriteLine();
            sw.WriteLine($"Radius is {radius}");
            var diameter = Vector_Degrees.GetDm(extr);
            sw.WriteLine($"Diameter is {diameter}");
            var CentralVert = Vector_Degrees.CentralVertices(extr);
            sw.Write("Central Vertices is ");
            CentralVert.ArrayOutput(sw);
            sw.WriteLine();
            var PeripheralVert = Vector_Degrees.PeripheralVertices(extr);
            sw.Write("Peripheral Vertices is ");
            PeripheralVert.ArrayOutput(sw);
            sw.WriteLine();

            void ShowHelp()
            {
                Console.WriteLine("Velkovskii Zahar\n Group: М3О-325Bk-21 \n №1 \n Keys: \n -m - The graph is read from the adjacency matrix \n -e - The graph is read from the list of edges \n -l - The graph is read from the adjacency list \n -o - The result is output to a file \n"                    );
            }
        }






    }

}