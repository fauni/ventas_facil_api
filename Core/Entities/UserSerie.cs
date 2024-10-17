using Core.Entities.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserSerie
    {
        public int Id { get; set; }
        public string IdUsuario { get; set; }
        public int IdSerie { get; set; }
        public string NombreSerie { get; set; }
    }
}
