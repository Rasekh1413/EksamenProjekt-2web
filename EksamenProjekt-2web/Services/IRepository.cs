using EFCZealand.Models;

namespace EFCZealand.Services;


public interface IRepository<T> where T : IHarId
{
	List<T> All { get; }

	int Create(T t);

	T? Read(int id);


	bool Delete(int id);
}

public interface IAkademiRepository : IRepository<Akademi>
{
}
public interface IStudielederRepository : IRepository<Studieleder>
{
}
public interface ILærerRepository : IRepository<Lærer>
{
}
public interface IKompetenceRepository : IRepository<Kompetence>
{
}
public interface IFagRepository : IRepository<Fag>
{
}
public interface IUddannelseRepository : IRepository<Uddannelse>
{
}
public interface ILærerOgKompetenceAllokeringRepository : IRepository<LærerOgKompetenceAllokering>
{
}
public interface IUddannelseOgLærerAllokeringRepository : IRepository<UddannelseOgLærerAllokering>
{
}
public interface IUddannelseOgFagAllokeringRepository : IRepository<UddannelseOgFagAllokering>
{
}