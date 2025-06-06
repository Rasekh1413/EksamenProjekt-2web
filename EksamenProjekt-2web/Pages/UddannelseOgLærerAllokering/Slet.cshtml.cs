
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.UddannelseOgL�rerAllokering;

public class SletModel : PageModel
{
	private IUddannelseOgL�rerAllokeringRepository _repo;

	[BindProperty]
	public Models.UddannelseOgL�rerAllokering Element { get; set; }

	public SletModel(IUddannelseOgL�rerAllokeringRepository repo)
	{
		_repo = repo;
	}

	public virtual IActionResult OnGet(int id)
	{
		Models.UddannelseOgL�rerAllokering? element = _repo.Read(id);

		if (element == null)
			return RedirectToPage("Error");

		Element = element;
		return Page();
	}

	public virtual IActionResult OnPost()
	{
		_repo.Delete(Element.Id);

		return RedirectToPage("Alle");
	}
}


