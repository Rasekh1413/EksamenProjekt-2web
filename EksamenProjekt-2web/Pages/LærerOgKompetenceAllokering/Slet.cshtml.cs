
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.L�rerOgKompetenceAllokering;

public class SletModel : PageModel
{
	private IL�rerOgKompetenceAllokeringRepository _repo;

	[BindProperty]
	public Models.L�rerOgKompetenceAllokering Element { get; set; }

	public SletModel(IL�rerOgKompetenceAllokeringRepository repo)
	{
		_repo = repo;
	}

	public virtual IActionResult OnGet(int id)
	{
		Models.L�rerOgKompetenceAllokering? element = _repo.Read(id);

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


