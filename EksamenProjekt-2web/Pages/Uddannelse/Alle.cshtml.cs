using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.Uddannelser;

public class AlleModel : PageModel
{
	private IUddannelseRepository _repo;

	public List<Models.Uddannelse> Data { get; private set; }

	public AlleModel(IUddannelseRepository repo)
	{
		_repo = repo;
	}

	public void OnGet()
	{
		Data = _repo.All;
	}

	public bool CanDelete(int id)
	{
		Models.Uddannelse? uddannelse = Data.Find(uddannelse => uddannelse.Id == id);

		return (uddannelse != null && uddannelse.Id == 0);
        //return (uddannelse != null && uddannelse.UddannelseId.Count == 0);
    }
}
