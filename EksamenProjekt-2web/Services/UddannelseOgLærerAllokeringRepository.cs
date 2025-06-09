using Microsoft.EntityFrameworkCore;
using EFCZealand.Models;

namespace EFCZealand.Services;

public class UddannelseOgLærerAllokeringRepository : EFCRepositoryBase<UddannelseOgLærerAllokering, ZealandDBContext>, IUddannelseOgLærerAllokeringRepository
{

    protected override IQueryable<UddannelseOgLærerAllokering> GetAllWithIncludes(DbContext context)
    {
        return base.GetAllWithIncludes(context)
            .Include(rUogL => rUogL.Lærer)
            .Include(rUogL => rUogL.Uddannelse)
            ;
    }

}
