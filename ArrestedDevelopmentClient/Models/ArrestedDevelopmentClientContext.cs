using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ArrestedDevelopmentClient.Models
{
    public class ArrestedDevelopmentClientContext : IdentityDbContext<ApplicationUser>
    {
        public ArrestedDevelopmentClientContext(DbContextOptions options) : base(options) { }
    }
}