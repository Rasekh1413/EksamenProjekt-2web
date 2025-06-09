using EFCZealand.Models;
using EFCZealand.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFCZealand.Pages.Akademier;

public class AlleModel : PageModel
{
	private IAkademiRepository _repo;

	public List<Models.Akademi> Data { get; private set; }


    public Models.Studieleder Studieleder { get; set; } = new Models.Studieleder();
    public Models.Uddannelse Uddannelse { get; set; } = new Models.Uddannelse();

    public SelectList UddannelseList { get; set; }
    public SelectList StudielederList { get; set; }


    public AlleModel(

        IAkademiRepository repo,

        IUddannelseRepository uddannelseRepo,
        IStudielederRepository studielederRepo)
    {
        _repo = repo;

        UddannelseList = new SelectList(uddannelseRepo.All, nameof(Uddannelse.Id), nameof(Uddannelse.UddannelseNavn));
        StudielederList = new SelectList(studielederRepo.All, nameof(Studieleder.Id), nameof(Studieleder.Navn));

        //Element.Dato = DateOnly.FromDateTime(DateTime.Now);

    }

    //public AlleModel(IAkademiRepository repo)
    //{
    //	_repo = repo;
    //}

    public void OnGet()
	{
		Data = _repo.All;
    }

	public bool CanDelete(int id)
	{
		Models.Akademi? akademier = Data.Find(akademi_er => akademi_er.Id == id);

		return (akademier != null && akademier.Uddannelses.Count == 0);
	}
}
