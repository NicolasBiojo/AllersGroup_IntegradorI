﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Cluster<T>
    {
        public Dictionary<String,List<T>> Clients;
        public String[] Position;
        public double[,] matrix;

        public Cluster(Dictionary<String, List<T>> dic)
        {
            Clients= dic;
            GeneratePosition();
            GenerateMatrix();
        }


        //que porcentaje tiene right es contenido en left
        public static double Relation_level(List<T> Left, List<T> Right)
        {
            double x = 0.0;
            //List<T> n = new List<T>();
            //n.AddRange(Right);
            //n.AddRange(Left);

            if (Left.Count() < Right.Count())
            {
                foreach (T data in Left)
                {
                    if (Right.Contains(data))
                        x++;
                }
                x = (double)x / Left.Count();
            }
            else
            {
                foreach (T data in Right)
                {
                    if (Left.Contains(data))
                        x++;
                }
                x = (double)x / Right.Count();
            }


           


            return x;


            //double x = 0.0;
            //foreach (T data in Right)
            //{
            //    if (Left.Contains(data))
            //        x++;
            //}

            //x = (double)x / Right.Count();
            //return x;
        }

        private void GeneratePosition()
        {

            int size = Clients.Count();
            Position = new String[size];
            int x = 0;

            foreach (var n in Clients)
            {
                Position[x] = n.Key;
                x++;
            }
        }

        private void GenerateMatrix()
        {
            int size = Clients.Count();
            matrix = new double[size, size];

            for (int i =0; i < size; i++)
            {
                //String aux = "";
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                    {
                        matrix[i, i] = -1;
                        //aux += relation + " ";
                    }

                    else
                    {
                        double relation = Relation_level(Clients[Position[i]], Clients[Position[j]]);
                        matrix [i, j] = relation ;
                        //aux += relation + " ";
                    }
                }
                //Console.WriteLine(aux);
            }
        }

        public Boolean Merge(double Similarity_level)
        {
            
            bool success = false;

            double max = 0.0;
            string one = "";
            string two = "";

            for (int i = 0; i < Position.Length; i++)
            {
                for (int j = 0; j < Position.Length; j++)
                {
                    
                    if (matrix[i,j] >= max && matrix[i, j]<=1.0)
                    {
                        max = matrix[i, j];
                        one = Position[i];
                        two = Position[j];
                    }
                }
                
            }

            
            if (max>=Similarity_level)
            {
               
                List<T> aux = Clients[one].ToList();
                Clients.Remove(one);
                Clients.Remove(two);


                String n = one + "," + two;
                Clients.Add(n, aux);
                success = true;

                Console.WriteLine(one);
                Console.WriteLine(two);
                Console.WriteLine((double)max);
                Console.WriteLine(Clients.Count());
                Console.WriteLine();
            }

            return success;
        }

        public void Clustering(double Similarity_level)
        {
            bool aux = true;

            while (aux)
            {
                aux = Merge(Similarity_level);
                GeneratePosition();
                GenerateMatrix();
            }  
        }

        public List<List<List<String>>> results()
        {
            //list of elements{n} => {0}= list of clients_cluster , {1}= list of items 
            var x = Clients.Select(n=> new List<List<String>> { n.Key.Split(',').ToList() , n.Value.Select(z=>z+"").ToList() }).ToList();
            return x;
        }
       
    }
}
