
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.UddannelseOgLærerAllokering;

public class SletModel : PageModel
{
	private IUddannelseOgLærerAllokeringRepository _repo;

	[BindProperty]
	public Models.UddannelseOgLærerAllokering Element { get; set; }

	public SletModel(IUddannelseOgLærerAllokeringRepository repo)
	{
		_repo = repo;
	}

	public virtual IActionResult OnGet(int id)
	{
		Models.UddannelseOgLærerAllokering? element = _repo.Read(id);

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


