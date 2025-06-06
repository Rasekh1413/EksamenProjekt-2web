
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.Uddannelser;

public class SletModel : PageModel
{
	private IUddannelseRepository _repo;

	[BindProperty]
	public Uddannelse Element { get; set; }

	public SletModel(IUddannelseRepository repo)
	{
		_repo = repo;
	}

	public virtual IActionResult OnGet(int id)
	{
        Uddannelse? element = _repo.Read(id);

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


