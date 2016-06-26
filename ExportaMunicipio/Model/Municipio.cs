using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportaMunicipio.Model
{
    [Table("Municipios")]
    public class Municipio
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public virtual UF UF { get; set; }
        public  int ufID { get; set; }
    }
}
