using Microsoft.EntityFrameworkCore;
using EFCZealand.Models;

namespace EFCZealand.Services;

public class UddannelseOgFagAllokeringRepository : EFCRepositoryBase<UddannelseOgFagAllokering, ZealandDBContext>, IUddannelseOgFagAllokeringRepository
{
    //protected override IQueryable<UddannelseOgFagAllokeringRepository> GetAllWithIncludes(DbContext context)
    //{
    //    return base.GetAllWithIncludes(context)

    //        .Include(rUddannelseOgFagAllokering => rUddannelseOgFagAllokering.Uddannelse)
    //        .Include(rUddannelseOgFagAllokering => rUddannelseOgFagAlloking.Fag)

    //;
    //}
}
