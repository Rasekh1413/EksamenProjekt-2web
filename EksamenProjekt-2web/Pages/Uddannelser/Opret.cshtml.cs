using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.Uddannelser;

public class OpretModel : PageModel
{
	private IUddannelseRepository _repo;

	[BindProperty]
	public Uddannelse Element { get; set; } = new Uddannelse();

	public OpretModel(IUddannelseRepository repo)
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
