using Microsoft.EntityFrameworkCore;
using EFCZealand.Models;

namespace EFCZealand.Services;

public abstract class EFCRepositoryBase<T, TContext> : IRepository<T> 
	where T : class, IHarId
	where TContext : DbContext, new()
{
	public List<T> All
	{
		get
		{
			using DbContext context = new TContext();

			return GetAllWithIncludes(context).ToList();
		}
	}

	public virtual int Create(T t)
	{
		using DbContext context = new TContext();

		//int id = NextId();
		//t.Id = id;

		context.Set<T>().Add(t);
		context.SaveChanges();

		return t.Id;
	}

	public T? Read(int id)
	{
		using DbContext context = new TContext();

		//return GetAllWithIncludes(context).FirstOrDefault(t => t.Id == id);    ---- Worked
        return GetAllWithIncludes(context).AsEnumerable().FirstOrDefault(t => t.Id == id);

    }

    public bool Delete(int id)
	{
		using DbContext context = new TContext();

		T? tEx = Read(id);
		if (tEx == null)
			return false;

		context.Set<T>().Remove(tEx);
		return (context.SaveChanges() > 0);
	}

	protected virtual IQueryable<T> GetAllWithIncludes(DbContext context)
	{
		return context.Set<T>();
	}

	private int NextId()
	{
		return All.Select(t => t.Id).DefaultIfEmpty(0).Max() + 1;
	}
}
