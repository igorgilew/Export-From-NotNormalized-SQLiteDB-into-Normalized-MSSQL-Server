using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vhodnoi
{
    class Treb
    {
        public int id { get; set; }
        public string text { get; set; }      
        public int idTreb { get; set; }
        public Treb(int id, string text, int idTreb)
        {
            this.id = id;
            this.text = text;           
            this.idTreb = idTreb;
        }
    }
}
