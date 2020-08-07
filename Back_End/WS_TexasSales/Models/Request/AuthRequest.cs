using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WS_TexasSales.Models.Request
{
    public class AuthRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Pass { get; set; }
    }
}
