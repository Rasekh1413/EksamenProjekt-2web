
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.Studieledere;

public class SletModel : PageModel
{
	private IStudielederRepository _repo;

	[BindProperty]
	public Studieleder Element { get; set; }

	public SletModel(IStudielederRepository repo)
	{
		_repo = repo;
	}

	public virtual IActionResult OnGet(int id)
	{
		Studieleder? element = _repo.Read(id);

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


