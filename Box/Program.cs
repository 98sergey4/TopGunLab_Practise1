﻿using Box.PL.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box
{
    class Program
    {
        static void Main(string[] args)
        {
            FighterManager box = new FighterManager();
            box.Start();
        }
    }
}
