
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.LærerOgKompetenceAllokering;

public class SletModel : PageModel
{
	private ILærerOgKompetenceAllokeringRepository _repo;

	[BindProperty]
	public Models.LærerOgKompetenceAllokering Element { get; set; }

	public SletModel(ILærerOgKompetenceAllokeringRepository repo)
	{
		_repo = repo;
	}

	public virtual IActionResult OnGet(int id)
	{
		Models.LærerOgKompetenceAllokering? element = _repo.Read(id);

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


