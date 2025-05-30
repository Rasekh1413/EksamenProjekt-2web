using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.Lærer;

public class OpretModel : PageModel
{
	private ILærereRepository _repo;

	[BindProperty]
	public Lærere Element { get; set; } = new Lærere();

	public OpretModel(ILærereRepository repo)
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
