using MFMFMS.Security.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MFMFMS.Security
{
    public class MFMFMSSecurityDBContext : IdentityDbContext<User>
    {
        public MFMFMSSecurityDBContext(DbContextOptions<MFMFMSSecurityDBContext> options) : base(options)
        {
            
        }

        protected MFMFMSSecurityDBContext()
        {
            
        }
    }
}
