using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.HukommelseRam;

public class AlleModel : PageModel
{
	private IHukommelseRamRepository _repo;

	public List<Models.HukommelseRam> Data { get; private set; }

	public AlleModel(IHukommelseRamRepository repo)
	{
		_repo = repo;
	}

	public void OnGet()
	{
		Data = _repo.All;
	}

	public bool CanDelete(int id)
	{
		Models.HukommelseRam? hukommelseRam = Data.Find(hukommelseRam_er => hukommelseRam_er.Id == id);

		return (hukommelseRam != null && hukommelseRam.Id == 0);
        //return (hukommelseRam != null && hukommelseRam.Uddannelses.Count == 0);
    }

}
