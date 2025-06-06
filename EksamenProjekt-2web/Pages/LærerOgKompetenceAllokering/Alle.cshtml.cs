using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.L�rerOgKompetenceAllokering;

public class AlleModel : PageModel
{
	private IL�rerOgKompetenceAllokeringRepository _repo;

	public List<Models.L�rerOgKompetenceAllokering> Data { get; private set; }

	public AlleModel(IL�rerOgKompetenceAllokeringRepository repo)
	{
		_repo = repo;
	}

	public void OnGet()
	{
		Data = _repo.All;
	}

	public bool CanDelete(int id)
	{
		Models.L�rerOgKompetenceAllokering? LOK = Data.Find(LOK_er => LOK_er.Id == id);

		return (LOK != null && LOK.Id == 0);
        //return (LOK != null && LOK.Id.Count == 0);
    }

}
