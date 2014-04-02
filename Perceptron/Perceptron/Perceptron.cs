using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Perceptron
    {
        public double[] weights;
        public double threshold;
        public double learningrate;


        //ctor
        public Perceptron()
        {
            weights = new double[12];
            threshold = 5;
            learningrate = 0.001; //slower rate and higher threshold gives better results
            for (int j = 0; j < 12; j++)
            {
                weights[j] = 0;
            }
        }

        //get total weight of current grid
        public double Sum(bool[,] grid, int w, int h)
        {
            double sum = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    for (int k = 0; k < w; k++)
                    {
                        sum += weights[(j * w) + k] * (grid[k, j] ? 1 : 0);
                    }
                }
            }
            return sum;
        }

        //print current weights
        public void Print()
        {
            Console.WriteLine("----------Current weights----------");
            for (int i = 0; i < 12; i++)
            {
                Console.Write("[{0}]", weights[i]);
                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        //apply learning set to weights
        public void Learn(Trainer[] trset, int w, int h)
        {
            while (true) //main loop
            {
                int errorcount = 0;
                Print();
                for (int i = 0; i < trset.Length; i++) //for each trainig set
                {
                    Console.Write("Set {0} - ", i + 1);
                    int result = Evaluate(trset[i].grid, w, h); //evaluate current training grid
                    int error = trset[i].expectedoutput - result; //0 if expected output matches, otherwise 1 or -1
                    if (error != 0) //change weights if error present
                    {
                        errorcount ++; //increase error count for next evaluation
                        for (int j = 0; j < h; j++)
                        {
                            for (int k = 0; k < w; k++)
                            {
                                //apply weight correction to appropriate weights
                                weights[(j * w) + k] += learningrate * error * (trset[i].grid[k, j] ? 1 : 0);
                            }
                        }

                    }
                }
                Console.WriteLine("Errors left: {0}", errorcount);
                if (errorcount == 0)
                {
                    Console.WriteLine("Done.");
                    break; //done if no more errors present
                }
            }
        }

        //evaluate grid
        public int Evaluate(bool[,] grid, int w, int h)
        {
            Console.WriteLine("Grid sum: {0}", Sum(grid, w, h));
            return Sum(grid, w, h) > threshold ? 1 : 0; //grid sum value within threshold? number recognized!
        }
    }
}
