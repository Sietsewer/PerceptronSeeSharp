using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Trainer
    {
        public bool[,] grid;
        public int expectedoutput;

        public Trainer(bool[,] grid, int expectedoutput)
        {
            this.grid = grid;
            this.expectedoutput = expectedoutput;
        }
    }
}
