using System;
using System.Collections.Generic;

namespace ApiTecnotienda.Models
{
    public partial class UserTable
    {
        public int IdUser { get; set; }
        public string? UserData { get; set; }
        public string? PasswordData { get; set; }
    }
}
