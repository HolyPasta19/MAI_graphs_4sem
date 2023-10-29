﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs8
{
    public class Cell
    {
	    public int height = -1;
        public int x = -1;
        public int y = -1;
        public int priority = 0;
        public bool PositionEqual(Cell other) 
        {
		     return x == other.x && y == other.y;
        }
	}
}
