using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS_TexasSales.Models.Request;
using WS_TexasSales.Models.Response;

namespace WS_TexasSales.Services
{
    public interface IUserService
    {
        UserResponse Response(AuthRequest auth);
    }
}
