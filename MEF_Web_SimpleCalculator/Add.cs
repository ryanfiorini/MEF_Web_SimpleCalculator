/*
 * This is an ASP.Net adaptaion of the example from Microsofts msdn site.
 * http://msdn.microsoft.com/en-us/library/dd460648.aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-9
 * 
 */

using MEFF_Web_Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace MEF_Web_SimpleCalculator
{
    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '+')]
    public class Add : IOperation
    {
        public int Operate(int left, int right)
        {
            return left + right;
        }
    }
}