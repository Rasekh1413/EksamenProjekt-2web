using EFCZealand.Models;
using EFCZealand.Services;
using Microsoft.EntityFrameworkCore;

namespace EFCZealand.Services;

public class UddannelseRepository : EFCRepositoryBase<Uddannelse, ZealandDBContext>, IUddannelseRepository
{
	protected override IQueryable<Uddannelse> GetAllWithIncludes(DbContext context)
	{
		return base.GetAllWithIncludes(context)

			.Include(rUddannelse => rUddannelse.UddannelseOgFagAllokerings)
			.Include(rUddannelse => rUddannelse.UddannelseOgLærerAllokerings)
			.Include(rUddannelse => rUddannelse.Akademi)
            ;
    }
}
