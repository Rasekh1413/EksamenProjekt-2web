using Microsoft.EntityFrameworkCore;
using EFCZealand.Models;

namespace EFCZealand.Services;

public class LærereRepository : EFCRepositoryBase<Lærere, ZealandDBContext>, ILærereRepository
{
	protected override IQueryable<Lærere> GetAllWithIncludes(DbContext context)
	{
		return base.GetAllWithIncludes(context)
			.Include(lærer => lærer.Akademi);
    }

	//public List<Lærere> AlleNavn
	//{
	//	get { return All.Where(lærer => lærer.Navn).ToList(); }
	//}
}
