using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.UddannelseOgLærerAllokering;

public class OpretModel : PageModel
{
	private IUddannelseOgLærerAllokeringRepository _repo;

	[BindProperty]
	public Models.UddannelseOgLærerAllokering Element { get; set; } = new Models.UddannelseOgLærerAllokering();

	public OpretModel(IUddannelseOgLærerAllokeringRepository repo)
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
