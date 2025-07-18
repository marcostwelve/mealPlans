using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model.Dto.Auth
{
    public class UserToken
    {
        public bool IsAuthenticated { get; set; }
        public DateTime Expires { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
