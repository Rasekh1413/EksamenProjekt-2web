using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.Studieledere;

public class OpretModel : PageModel
{
	private IStudielederRepository _repo;

	[BindProperty]
	public Studieleder Element { get; set; } = new Studieleder();

	public OpretModel(IStudielederRepository repo)
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
