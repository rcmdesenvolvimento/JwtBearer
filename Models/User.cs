using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtBearer.Models
{
    public record User(int id,
                  string Email,
                  string Password,
                  string[] Roles);
}
