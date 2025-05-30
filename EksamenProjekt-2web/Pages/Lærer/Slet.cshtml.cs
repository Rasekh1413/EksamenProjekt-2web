
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.Lærer;

public class SletModel : PageModel
{
	private ILærereRepository _repo;

	[BindProperty]
	public Lærere Element { get; set; }

	public SletModel(ILærereRepository repo)
	{
		_repo = repo;
	}

	public virtual IActionResult OnGet(int id)
	{
		Lærere? element = _repo.Read(id);

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


