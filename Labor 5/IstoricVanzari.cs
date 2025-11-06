using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor_5
{
    public class IstoricVanzari
    {
        public int Id { get; set; }
        public int IdProdus { get; set; }
        public int Cantitate { get; set; }

        public Product Produs { get; set; }
    }
}
