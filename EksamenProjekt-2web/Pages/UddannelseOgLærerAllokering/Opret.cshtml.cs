using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.UddannelseOgL�rerAllokering;

public class OpretModel : PageModel
{
	private IUddannelseOgL�rerAllokeringRepository _repo;

	[BindProperty]
	public Models.UddannelseOgL�rerAllokering Element { get; set; } = new Models.UddannelseOgL�rerAllokering();

	public OpretModel(IUddannelseOgL�rerAllokeringRepository repo)
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
