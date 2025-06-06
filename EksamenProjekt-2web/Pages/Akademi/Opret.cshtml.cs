using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.Akademier;

public class OpretModel : PageModel
{
	private IAkademiRepository _repo;

	[BindProperty]
	public Akademi Element { get; set; } = new Akademi();

	public OpretModel(IAkademiRepository repo)
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
