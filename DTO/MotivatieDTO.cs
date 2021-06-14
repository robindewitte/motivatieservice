using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace motivatieservice.DTO
{
    public class MotivatieDTO
    {
        private string username;

        public MotivatieDTO()
        {

        }
        public MotivatieDTO(string username)
        {
            this.Username = username;
        }

        public string Username { get => username; set => username = value; }
    }
}
