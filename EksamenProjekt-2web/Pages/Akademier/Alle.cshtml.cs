using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.Akademier;

public class AlleModel : PageModel
{
	private IAkademiRepository _repo;

	public List<Akademi> Data { get; private set; }

	public AlleModel(IAkademiRepository repo)
	{
		_repo = repo;
	}

	public void OnGet()
	{
		Data = _repo.All;
	}

	public bool CanDelete(int id)
	{
		Akademi? akademi = Data.Find(akademi_er => akademi_er.Id == id);

		return (akademi != null && akademi.Uddannelses.Count == 0);
	}
}
