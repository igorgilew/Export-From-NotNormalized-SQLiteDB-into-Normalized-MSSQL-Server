using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vhodnoi
{
    class TableNotNormalized
    {
        public int id { get; set; }
        public string number { get; set; }
        public string date { get; set; }
        public string nameSud { get; set; }
        public string sostavSud { get; set; }
        public string secretar { get; set; }
        public string istecName { get; set; }
        public string predstIstcaName { get; set; }
        public string documentPredst { get; set; }
        public string otvetchName { get; set; }
        public string predstOtvetchName { get; set; }
        public string documentPredstOtv { get; set; }
        public string trebovanie { get; set; }
        public TableNotNormalized(int id, string number, DateTime date, string nameSud, string sostavSud,
            string secretar, string istecName, string predstIstcaName, string documentPredst,
            string otvetchName, string predstOtvetchName, string documentPredstOtv, string trebovanie)
        {
            this.id = id;
            this.number = number;
            this.date = date.ToShortDateString();
            this.nameSud = nameSud;
            this.sostavSud = sostavSud;
            this.secretar = secretar;
            this.istecName = istecName;
            this.predstIstcaName = predstIstcaName;
            this.documentPredst = documentPredst;
            this.otvetchName = otvetchName;
            this.predstOtvetchName = predstOtvetchName;
            this.documentPredstOtv = documentPredstOtv;
            this.trebovanie = trebovanie;
        }

    }
}
