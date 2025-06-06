using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.LærerOgKompetenceAllokering;

public class AlleModel : PageModel
{
	private ILærerOgKompetenceAllokeringRepository _repo;

	public List<Models.LærerOgKompetenceAllokering> Data { get; private set; }

	public AlleModel(ILærerOgKompetenceAllokeringRepository repo)
	{
		_repo = repo;
	}

	public void OnGet()
	{
		Data = _repo.All;
	}

	public bool CanDelete(int id)
	{
		Models.LærerOgKompetenceAllokering? LOK = Data.Find(LOK_er => LOK_er.Id == id);

		return (LOK != null && LOK.Id == 0);
        //return (LOK != null && LOK.Id.Count == 0);
    }

}
