using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vhodnoi
{
    class Otv
    {
        public int id { get; set; }
        public string name { get; set; }
        public int idDoc { get; set; }
        public Otv(int id, string name, int idDoc)
        {
            this.id = id;
            this.name = name;
            this.idDoc = idDoc;
        }
    }
}
