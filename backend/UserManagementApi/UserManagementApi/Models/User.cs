using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagementApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }  // O password será armazenado de forma segura (com hash)
        public string Email { get; set; }
        public string Permission { get; set; } // Pode ser "admin" ou "standard"
        public string Phone { get; set; }
    }
}