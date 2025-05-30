using Microsoft.EntityFrameworkCore;
using EFCZealand.Models;

namespace EFCZealand.Services;

public class FagRepository : EFCRepositoryBase<Fag, ZealandDBContext>, IFagRepository
{
	protected override IQueryable<Fag> GetAllWithIncludes(DbContext context)
	{
		return base.GetAllWithIncludes(context)
			.Include(f => f.Uddannelse);

	}
}
