using Microsoft.EntityFrameworkCore;
using EFCZealand.Models;

namespace EFCZealand.Services;

public class AkademiRepository : EFCRepositoryBase<Akademi, ZealandDBContext>, IAkademiRepository
{

    protected override IQueryable<Akademi> GetAllWithIncludes(DbContext context)
    {
        return base.GetAllWithIncludes(context)
            .Include(s => s.Uddannelses)
          //Include(navigationPropertyPath: s => s.Uddannelses)
          ;
    }
}
