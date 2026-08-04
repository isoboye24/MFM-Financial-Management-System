using MFMFMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MFMFMS.Persistence
{
    public class MFMFMSDBContext : DbContext
    {
        public MFMFMSDBContext(DbContextOptions<MFMFMSDBContext> options) : base(options)
        {

        }
    }
}
