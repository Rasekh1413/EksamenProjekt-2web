using EFCZealand.Models;
using EFCZealand.Services;
using Microsoft.EntityFrameworkCore;

namespace EFCZealand.Services;

public class KompetencerRepository : EFCRepositoryBase<Kompetence, ZealandDBContext>, IKompetenceRepository
{
	protected override IQueryable<Kompetence> GetAllWithIncludes(DbContext context)
	{
		return base.GetAllWithIncludes(context);
	}
}
