using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.Kompetencer;

public class OpretModel : PageModel
{
	private IKompetencerRepository _repo;

	[BindProperty]
	public Models.Kompetencer Element { get; set; } = new Models.Kompetencer();

	public OpretModel(IKompetencerRepository repo)
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
