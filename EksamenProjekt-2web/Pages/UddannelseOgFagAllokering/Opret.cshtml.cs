using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.UddannelseOgFagAllokering;

public class OpretModel : PageModel
{
	private IUddannelseOgFagAllokeringRepository _repo;

	[BindProperty]
	public Models.UddannelseOgFagAllokering Element { get; set; } = new Models.UddannelseOgFagAllokering();

	public OpretModel(IUddannelseOgFagAllokeringRepository repo)
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
