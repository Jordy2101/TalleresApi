using TALLER.ENTITY.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Options;

namespace TALLER.ENTITY
{
    public class TalleresContext : DbContext 
    {

        public TalleresContext(DbContextOptions<TalleresContext> options) : base(options)
        {

        }
            
            
    }
}
