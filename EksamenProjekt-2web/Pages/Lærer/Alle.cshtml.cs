using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.L�rer;

public class AlleModel : PageModel
{
	private IL�rereRepository _repo;

	public List<L�rere> Data { get; private set; }

	public AlleModel(IL�rereRepository repo)
	{
		_repo = repo;
	}

	public void OnGet()
	{
		Data = _repo.All;
	}

	public bool CanDelete(int id)
	{
		L�rere? l�rere = Data.Find(l�rere_er => l�rere_er.Id == id);

		return (l�rere != null && l�rere.Id == 0);
        //return (l�rere != null && l�rere.Id.Count == 0);
    }
}
