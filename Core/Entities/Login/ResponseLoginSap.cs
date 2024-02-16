using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Login
{
    public class ResponseLoginSap
    {
        public string SessionId { get; set; }
        public string Version { get; set; }
        public bool isCorrect { get; set; }
    }
}
