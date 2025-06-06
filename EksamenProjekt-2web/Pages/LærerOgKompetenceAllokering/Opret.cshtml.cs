using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.LærerOgKompetenceAllokering;

public class OpretModel : PageModel
{
	private ILærerOgKompetenceAllokeringRepository _repo;

	[BindProperty]
	public Models.LærerOgKompetenceAllokering Element { get; set; } = new Models.LærerOgKompetenceAllokering();

	public OpretModel(ILærerOgKompetenceAllokeringRepository repo)
	{
		_repo = repo;
	}

	public IActionResult OnPost()
	{
		if (!ModelState.IsValid)
		{
			return Page();
		}

		_repo.Create(Element);

		return RedirectToPage("Alle");
	}
}
