using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vhodnoi
{
    class Document
    {
        public int id { get; set; }
        public string numDoc { get; set; }
        public string date { get; set; }
        public string nameSud { get; set; }
        public string sostavSud { get; set; }
        public string secretar { get; set; }
        public Document(int id, string numDoc, DateTime date, string nameSud, string sostavSud, string secretar)
        {
            this.id = id;
            this.numDoc = numDoc;
            this.date = date.ToShortDateString();
            this.nameSud = nameSud;
            this.sostavSud = sostavSud;
            this.secretar = secretar;
        }


    }
}
