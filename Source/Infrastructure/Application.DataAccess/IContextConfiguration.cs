using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Application.DataAccess
{
    public interface IContextConfiguration
    {
        DbContextOptions GetDbContextOptions();
    }
}