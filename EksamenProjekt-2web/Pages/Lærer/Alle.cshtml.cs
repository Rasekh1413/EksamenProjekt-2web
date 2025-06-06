using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.L�rer;

public class AlleModel : PageModel
{
	private IL�rerRepository _repo;

	public List<Models.L�rer> Data { get; private set; }

	public AlleModel(IL�rerRepository repo)
	{
		_repo = repo;
	}

	public void OnGet()
	{
		Data = _repo.All;
	}

	public bool CanDelete(int id)
	{
		Models.L�rer? l�rere = Data.Find(l�rere_er => l�rere_er.Id == id);

		return (l�rere != null && l�rere.Id == 0);
        //return (l�rere != null && l�rere.Count == 0);
    }
}
