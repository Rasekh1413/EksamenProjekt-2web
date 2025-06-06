using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenProjekt_2web.Pages.Kort
{
    public class KortModel : PageModel
    {
        public List<Location> AkademiLokationer { get; set; } = new List<Location>();

        public void OnGet()
        {
            AkademiLokationer = new List<Location>
            {
                new Location { Name = "Zealand Roskilde", Latitude = 55.6415, Longitude = 12.0803 },
                new Location { Name = "Zealand Køge", Latitude = 55.4580, Longitude = 12.1821 },
                new Location { Name = "Zealand Næstved", Latitude = 55.2290, Longitude = 11.7609 },
                new Location { Name = "Zealand Nykøbing Falster", Latitude = 54.7680, Longitude = 11.8741 },
                new Location { Name = "Zealand Slagelse", Latitude = 55.4028, Longitude = 11.3546 },
                new Location { Name = "Zealand Holbæk", Latitude = 55.7160, Longitude = 11.7167 },
                new Location { Name = "Zealand Nødebo", Latitude = 55.9803, Longitude = 12.3452 },
            };
        }
    }

    public class Location
    {
        public string Name { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}

