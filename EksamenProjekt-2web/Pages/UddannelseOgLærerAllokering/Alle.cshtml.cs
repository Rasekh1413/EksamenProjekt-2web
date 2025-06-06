using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.UddannelseOgL�rerAllokering;

public class AlleModel : PageModel
{
	private IUddannelseOgL�rerAllokeringRepository _repo;

	public List<Models.UddannelseOgL�rerAllokering> Data { get; private set; }

	public AlleModel(IUddannelseOgL�rerAllokeringRepository repo)
	{
		_repo = repo;
	}

	public void OnGet()
	{
		Data = _repo.All;
	}

	public bool CanDelete(int id)
	{
		Models.UddannelseOgL�rerAllokering? UOL = Data.Find(UOL_er => UOL_er.Id == id);

		return (UOL != null && UOL.Id == 0);
        //return (hukommelseRam != null && hukommelseRam.Uddannelses.Count == 0);
    }

}
