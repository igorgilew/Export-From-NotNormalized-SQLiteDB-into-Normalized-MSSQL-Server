using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vhodnoi
{
    class PredstIst
    {
        public int id { get; set; }
        public string name { get; set; }
        public string doc { get; set; }
        public int idClienta { get; set; }
        public PredstIst(int id, string name, string doc, int idClienta)
        {
            this.id = id;
            this.name = name;
            this.doc = doc;
            this.idClienta = idClienta;
        }
    }
}
