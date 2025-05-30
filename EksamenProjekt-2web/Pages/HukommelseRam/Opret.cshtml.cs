using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.HukommelseRam;

public class OpretModel : PageModel
{
	private IHukommelseRamRepository _repo;

	[BindProperty]
	public Models.HukommelseRam Element { get; set; } = new Models.HukommelseRam();

	public OpretModel(IHukommelseRamRepository repo)
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
