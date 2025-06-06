using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.UddannelseOgFagAllokering;

public class AlleModel : PageModel
{
	private IUddannelseOgFagAllokeringRepository _repo;

	public List<Models.UddannelseOgFagAllokering> Data { get; private set; }

	public AlleModel(IUddannelseOgFagAllokeringRepository repo)
	{
		_repo = repo;
	}

	public void OnGet()
	{
		Data = _repo.All;
	}

	public bool CanDelete(int id)
	{
		Models.UddannelseOgFagAllokering? UOF = Data.Find(UOF_er => UOF_er.Id == id);

		return (UOF != null && UOF.Id == 0);
        //return (UOF != null && UOF.Uddannelses.Count == 0);
    }

}
