using EFCZealand.Models;
using EFCZealand.Services;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFCZealand.Pages.Akademier;

public class OpretModel : PageModel
{
	private IAkademiRepository _repo;

	[BindProperty]
	public Akademi Element { get; set; } = new Akademi();

	public SelectList UddannelseList { get; set; }
    public SelectList StudielederList { get; set; }
    

    public OpretModel(
	
        IAkademiRepository repo,

        IUddannelseRepository uddannelseRepo,
		IStudielederRepository studielederRepo)
	{ 
        _repo = repo;

        UddannelseList = new SelectList(uddannelseRepo.All, nameof(Uddannelse.Id), nameof(Uddannelse.UddannelseNavn));
        StudielederList = new SelectList(studielederRepo.All, nameof(Studieleder.Id), nameof(Studieleder.Navn));

        //Element.Dato = DateOnly.FromDateTime(DateTime.Now);

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
