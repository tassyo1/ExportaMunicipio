using ExportaMunicipio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportaMunicipio.DAO
{
   public class MunicipioDAO
    {
        private Contexto contexto;
        public MunicipioDAO()
        {
            this.contexto = new Contexto();
        }

        public IList<Municipio> MunicipiosPorUF(int ufID)
        {
            UF uf = contexto.Estados.Find(ufID);

            var busca = from m in contexto.Municipios
                        where m.ufID == uf.ID
                        orderby m.Nome
                        select m;

            return  busca.ToList();
        }
    }
}
