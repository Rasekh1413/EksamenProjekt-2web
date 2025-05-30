using EFCZealand.Models;
using EFCZealand.Services;
using Microsoft.EntityFrameworkCore;

namespace EFCZealand.Services;

public class KompetencerRepository : EFCRepositoryBase<Kompetencer, ZealandDBContext>, IKompetencerRepository
{
	protected override IQueryable<Kompetencer> GetAllWithIncludes(DbContext context)
	{
		return base.GetAllWithIncludes(context);
	}
}
