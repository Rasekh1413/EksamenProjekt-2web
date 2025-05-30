
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.L�rer;

public class SletModel : PageModel
{
	private IL�rereRepository _repo;

	[BindProperty]
	public L�rere Element { get; set; }

	public SletModel(IL�rereRepository repo)
	{
		_repo = repo;
	}

	public virtual IActionResult OnGet(int id)
	{
		L�rere? element = _repo.Read(id);

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


