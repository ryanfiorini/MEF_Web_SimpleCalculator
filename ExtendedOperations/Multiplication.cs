﻿using MEFF_Web_Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedOperations
{
    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '*')]
    public class Multiplication : IOperation
    {
        public int Operate(int left, int right)
        {
            return left % right;
        }
    }
}
