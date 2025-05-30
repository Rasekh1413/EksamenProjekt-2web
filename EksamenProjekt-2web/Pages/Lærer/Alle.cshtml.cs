using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.Lærer;

public class AlleModel : PageModel
{
	private ILærereRepository _repo;

	public List<Lærere> Data { get; private set; }

	public AlleModel(ILærereRepository repo)
	{
		_repo = repo;
	}

	public void OnGet()
	{
		Data = _repo.All;
	}

	public bool CanDelete(int id)
	{
		Lærere? lærere = Data.Find(lærere_er => lærere_er.Id == id);

		return (lærere != null && lærere.Id == 0);
        //return (lærere != null && lærere.Id.Count == 0);
    }
}
