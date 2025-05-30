using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.Kompetencer;

public class AlleModel : PageModel
{
	private IKompetencerRepository _repo;

	public List<Models.Kompetencer> Data { get; private set; }

	public AlleModel(IKompetencerRepository repo)
	{
		_repo = repo;
	}

	public void OnGet()
	{
		Data = _repo.All;
	}

	public bool CanDelete(int id)
	{
        Models.Kompetencer? kompetence = Data.Find(kompetence_er => kompetence_er.Id == id);

		return (kompetence != null && kompetence.Id == 0);
        //return (kompetence != null && kompetence.Id.Count == 0);
    }
}
