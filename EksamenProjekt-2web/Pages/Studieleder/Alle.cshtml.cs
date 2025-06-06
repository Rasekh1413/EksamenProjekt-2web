using EFCZealand.Models;
using EFCZealand.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EFCZealand.Pages.Studieledere;

public class AlleModel : PageModel
{
	private IStudielederRepository _repo;

	public List<Models.Studieleder> Data { get; private set; }

	public AlleModel(IStudielederRepository repo)
	{
		_repo = repo;
	}

	public void OnGet()
	{
		Data = _repo.All;
    }

    public bool CanDelete(int id)
	{
		Studieleder? studieleder = Data.Find(studieleder_er => studieleder_er.Id == id);

		return (studieleder != null && studieleder.Id == 0);
        //return (studieleder != null && studieleder.Count == 0);
    }
}
