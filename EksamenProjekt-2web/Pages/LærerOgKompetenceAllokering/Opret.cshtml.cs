using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.L�rerOgKompetenceAllokering;

public class OpretModel : PageModel
{
	private IL�rerOgKompetenceAllokeringRepository _repo;

	[BindProperty]
	public Models.L�rerOgKompetenceAllokering Element { get; set; } = new Models.L�rerOgKompetenceAllokering();

	public OpretModel(IL�rerOgKompetenceAllokeringRepository repo)
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
