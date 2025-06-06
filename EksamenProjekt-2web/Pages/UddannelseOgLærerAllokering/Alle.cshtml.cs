using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.UddannelseOgLærerAllokering;

public class AlleModel : PageModel
{
	private IUddannelseOgLærerAllokeringRepository _repo;

	public List<Models.UddannelseOgLærerAllokering> Data { get; private set; }

	public AlleModel(IUddannelseOgLærerAllokeringRepository repo)
	{
		_repo = repo;
	}

	public void OnGet()
	{
		Data = _repo.All;
	}

	public bool CanDelete(int id)
	{
		Models.UddannelseOgLærerAllokering? UOL = Data.Find(UOL_er => UOL_er.Id == id);

		return (UOL != null && UOL.Id == 0);
        //return (hukommelseRam != null && hukommelseRam.Uddannelses.Count == 0);
    }

}
