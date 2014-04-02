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

        public Perceptron()
        {
            weights = new double[12];
            threshold = 1;
            learningrate = 0.1;
            for (int j = 0; j < 12; j++)
            {
                weights[j] = 0;
            }
        }

        public double Sum(bool[,] grid, int w, int h)
        {
            double sum = 0;
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    sum += grid[j, i] ? weights[(i * w) + j] : 0;
                }
            }
            return sum;
        }

        public void Print()
        {
            Console.WriteLine("---------------------------------------");
            for (int i = 0; i < 12; i++)
            {
                Console.Write(weights[i]);
                Console.Write('.');
                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        public void Learn(Trainer[] trset, int w, int h)
        {

            while (true)
            {
                int errorcount = 0;
                Print();
                for (int i = 0; i < trset.Length; i++)
                {
                    int result = Sum(trset[i].grid, w, h) > threshold ? 1 : 0;
                    Console.WriteLine(Sum(trset[i].grid, w, h));
                    int error = trset[i].expectedoutput - 2 * result;
                    if (error != 0)
                    {
                        errorcount += 1;
                        for (int j = 0; j < h; j++)
                        {
                            for (int k = 0; k < w; k++)
                            {
                                weights[(j * w) + k] += learningrate * error * (trset[i].grid[k, j] ? 1 : 0);
                            }
                        }

                    }
                }
                Console.WriteLine(errorcount);
                Console.ReadLine();
                if (errorcount == 0)
                {
                    break;
                }
            }
        }

        public int Evaluate(bool[,] grid, int w, int h)
        {
            return Sum(grid, w, h) > threshold ? 1 : 0;
        }
    }
}
