using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ExportaMunicipio.Model;
namespace ExportaMunicipio
{
    class Contexto :DbContext
    {
        public DbSet<UF> Estados { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
    }
}
