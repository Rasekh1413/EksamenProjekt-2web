using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCZealand.Models;
using EFCZealand.Services;

namespace EFCZealand.Pages.Fager;

public class AlleModel : PageModel
{
	private IFagRepository _repo;

	public List<Models.Fag> Data { get; private set; }

	public AlleModel(IFagRepository repo)
	{
		_repo = repo;
	}

	public void OnGet()
	{
		Data = _repo.All;
	}

	public bool CanDelete(int id)
	{
		Models.Fag? fag = Data.Find(fag_er => fag_er.Id == id);

		return (fag != null && fag.Kompetences.Count == 0);
    }
}
