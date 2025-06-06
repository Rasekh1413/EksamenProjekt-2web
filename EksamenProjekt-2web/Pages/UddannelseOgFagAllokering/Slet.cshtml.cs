
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.UddannelseOgFagAllokering;

public class SletModel : PageModel
{
	private IUddannelseOgFagAllokeringRepository _repo;

	[BindProperty]
	public Models.UddannelseOgFagAllokering Element { get; set; }

	public SletModel(IUddannelseOgFagAllokeringRepository repo)
	{
		_repo = repo;
	}

	public virtual IActionResult OnGet(int id)
	{
		Models.UddannelseOgFagAllokering? element = _repo.Read(id);

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


