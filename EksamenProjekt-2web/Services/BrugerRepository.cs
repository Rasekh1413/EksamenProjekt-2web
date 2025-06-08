//using EFCZealand.Models;
//using Microsoft.AspNetCore.Identity;
//using static EFCZealand.Services.BrugerRepository;

//namespace EFCZealand.Services;


//public class BrugerRepository : EFCRepositoryBase<Bruger, ZealandDBContext>, IBrugerRepository
//{
//    private PasswordHasher<string> _passwordHasher;

//    public BrugerRepository()
//    {
//        _passwordHasher = new PasswordHasher<string>();
//    }

//    public List<string> Roller
//    {
//        get { return new List<string> { "Studueleder", "Lærer" }; }
//    }


//    //--------------------
//    //public override int Create(User user)
//    //{
//    //	user.Password = _passwordHasher.HashPassword(user.Navn, user.Password);
//    //	return base.Create(user);
//    //}
//    //--------------------


//    public Bruger? TjekBruger(string GivetBrugerNavn, string GivetAdgangskode)
//    {
//        Bruger? bruger = All.FirstOrDefault(u => u.Navn == GivetBrugerNavn);

//        // User findes ikke, eller har angivet forkert password
//        if (bruger == null || !VerifyPassword(bruger, GivetAdgangskode))
//            return null;

//        return bruger;
//    }



//   //--------------------
//    //private bool VerifyPassword(User user, string providedPassword)
//    //{
//    //	PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(
//    //		user.Navn, user.Password, providedPassword);

//    //	return result == PasswordVerificationResult.Success;
//    //}
//    //--------------------




//    private bool VerifyPassword(Bruger bruger, string GivetAdgangskode)
//    {
//        return bruger.Password == GivetAdgangskode;
//    }

//}

