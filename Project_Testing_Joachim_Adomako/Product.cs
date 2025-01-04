using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Testing_Joachim_Adomako
{
    public class Product
    {
        public string Name { get; set; }
        public int CurrentStock { get; set; }
        public int MinStock { get; set; }
        public int ExpectedDemand { get; set; }
    }
}
