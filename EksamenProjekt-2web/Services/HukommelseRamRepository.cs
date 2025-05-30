using Microsoft.EntityFrameworkCore;
using EFCZealand.Models;

namespace EFCZealand.Services;

public class HukommelseRamRepository : EFCRepositoryBase<HukommelseRam, ZealandDBContext>, IHukommelseRamRepository
{
	protected override IQueryable<HukommelseRam> GetAllWithIncludes(DbContext context)
	{
		return base.GetAllWithIncludes(context)
			.Include(l => l.Akademi)
			.Include(l => l.Uddannelse)
			.Include(l => l.Fag)
			.Include(l => l.Lærer)
			.Include(l => l.HukommelseRamid)
			.Include(l => l.Kompetence);
    }
}
