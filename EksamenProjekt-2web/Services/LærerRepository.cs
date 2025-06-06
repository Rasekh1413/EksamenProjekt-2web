using Microsoft.EntityFrameworkCore;
using EFCZealand.Models;

namespace EFCZealand.Services;

public class LærerRepository : EFCRepositoryBase<Lærer, ZealandDBContext>, ILærerRepository
{
	protected override IQueryable<Lærer> GetAllWithIncludes(DbContext context)
	{
		return base.GetAllWithIncludes(context)
			.Include(lærer => lærer.UddannelseOgLærerAllokerings)
			;
    }

	//public List<Lærere> AlleNavn
	//{
	//	get { return All.Where(lærer => lærer.Navn).ToList(); }
	//}
}
