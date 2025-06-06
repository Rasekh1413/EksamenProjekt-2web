using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.Kompetencer;

public class AlleModel : PageModel
{
	private IKompetenceRepository _repo;

	public List<Models.Kompetence> Data { get; private set; }

	public AlleModel(IKompetenceRepository repo)
	{
		_repo = repo;
	}

	public void OnGet()
	{
		Data = _repo.All;
	}

	public bool CanDelete(int id)
	{
        Models.Kompetence? kompetencer = Data.Find(kompetence_er => kompetence_er.Id == id);

		return (kompetencer != null && kompetencer.Id == 0);
        //return (kompetencer != null && kompetencer.Id.Count == 0);
    }
}
