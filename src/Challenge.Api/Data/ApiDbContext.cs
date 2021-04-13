using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.Api.Data
{
    public class ApiDbContext : IdentityDbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
    }
}
