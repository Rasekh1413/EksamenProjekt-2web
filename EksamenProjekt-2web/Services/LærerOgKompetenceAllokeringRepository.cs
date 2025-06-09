using Microsoft.EntityFrameworkCore;
using EFCZealand.Models;

namespace EFCZealand.Services;

public class LærerOgKompetenceAllokeringRepository : EFCRepositoryBase<LærerOgKompetenceAllokering, ZealandDBContext>, ILærerOgKompetenceAllokeringRepository
{
	protected override IQueryable<LærerOgKompetenceAllokering> GetAllWithIncludes(DbContext context)
	{
		return base.GetAllWithIncludes(context)

			.Include(rLærerOgKompetenceAllokering => rLærerOgKompetenceAllokering.Lærer)
			.Include(rLærerOgKompetenceAllokering => rLærerOgKompetenceAllokering.Kompetence)
    ;
    }
}
