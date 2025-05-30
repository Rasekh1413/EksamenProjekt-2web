using EFCZealand.Models;
using EFCZealand.Services;
using Microsoft.EntityFrameworkCore;

namespace EFCZealand.Services;

public class StudielederRepository : EFCRepositoryBase<Studieleder, ZealandDBContext>, IStudielederRepository
{
	protected override IQueryable<Studieleder> GetAllWithIncludes(DbContext context)
	{
		return base.GetAllWithIncludes(context);
		
	}
}
