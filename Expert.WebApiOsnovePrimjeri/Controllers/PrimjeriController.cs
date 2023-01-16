using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Expert.WebApiOsnovePrimjeri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimjeriController : ControllerBase
    {
        [HttpGet("primjer-1")]
        public ActionResult<string> NestedIf()
        {
            int x = 5, y = 20;
            if (x > y)
            {
                if (x >= 10)
                {
                    return "x je veći ili jednak y 10";
                }
                else
                {
                    return "x je manji od 10";
                }
            }
            else
            {
                if (y <= 20)
                {
                    return "y je manji ili jednak 20";
                }
                else
                {
                    return "y je veći od 20";
                }
            }
        }

        [HttpGet("primjer-2")]
        public ActionResult<string> ElseIfExample()
        {
            int x = 5;
            if (x == 10)
            {
                return "x je jednak 10";
            }
            else if (x > 10)
            {
                return "x je veći od 10";
            }
            else
            {
                return "x value less than 10";
            }
        }

        [HttpGet("primjer-3")]
        public ActionResult<List<string>> ForLoop()
        {
            List<string> vratiRezultat = new List<string>();
            //u for petlji možemo definirati više parametara bitno je samo da ih odvajamo zarezom
            for (int i = 1, j = 0; i <= 4; i++, j++)
            {
                vratiRezultat.Add($"i: {i}, j: {j}");
            }

            return vratiRezultat;
        }

        [HttpGet("primjer-4")]
        public ActionResult<string> ForLoopWithBreak()
        {
            string vratiRezultat = "";
            //petlju možemo prekinuti sa break naredbom ako nađemo uvjet koji nas zadovoljava
            for (int i = 1; i <= 4; i++)
            {
                //if i petlje kao i sve ostalo možemo koristiti jedan unutar drugoga sve dok je kod ispravno enkapsuliran
                if (i == 3)
                {
                    vratiRezultat = $"i value: {i}";
                    break;
                }
            }

            return vratiRezultat;
        }

        [HttpGet("primjer-5")]
        public ActionResult<List<string>> ForLoopInForLoop()
        {
            List<string> vratiRezultat = new List<string>();
            //a možemo koristiti i petlju u petlji
            for (int i = 1; i <= 4; i++)
            {
                for (int j = i; j < 3; j++)
                {
                    vratiRezultat.Add($"i value: {i}, j value: {j}");
                }
            }

            return vratiRezultat;
        }

        [HttpGet("primjer-6")]
        public ActionResult<List<string>> ForEach()
        {
            //Ovo je kompleksni objekt tipa liste. Njega moramo instancirati (napraviti novu radnu kopiju postojećeg objekta
            //a instanciranje radimo sa rezerviranom riječi "new"
            List<string> vratiImena = new List<string>();

            //Ovo je array lista njega definiramo tako da tipu objekta dodamo uglate zagrade, npr int[], string[] itd.
            //u vitičastim zagradama dodajemo inicijalne vrijednosti u listu tzv. preddefinirane item-e
            string[] imena = new string[3] { "Pero Perić", "Nik Titanik", "Marko Marić" };

            //u ovom primjeru jednostavno prepisujemo iteme(stavke) iz jedne liste u drugu
            foreach (string ime in imena)
            {
                //lista kao kompleksan objekt koji može sadržavati n vrijednosti ima neke svoje preddefinirane metode sa rad sa listama
                //neke od metoda su add (dodaj) remove (ukloni) sort (posloži) itd.
                vratiImena.Add(ime);
            }

            return vratiImena;
        }

        [HttpGet("primjer-7/{prviBroj}/{drugiBroj}")]
        public ActionResult<string> PrimjerSedam(string prviBroj, int drugiBroj)
        {
            //provjeri da li je potrebno convertirati varijable u integer
            if (prviBroj.GetType() == typeof(int) && drugiBroj.GetType() == typeof(int))
            {
                return (prviBroj + drugiBroj).ToString();
            }
            else if (prviBroj.GetType() == typeof(string) && drugiBroj.GetType() == typeof(string))
            {
                return "Oba parametra su stringovi i ne možemo s njima raditi mat. operacije";
            }
            else
            {
                int prvi;
                bool testPrvi = int.TryParse(prviBroj.ToString(), out prvi);
                if (testPrvi != true)
                {
                    return $"nemogu konvertirti u broj: {prviBroj}";
                }
                int drugi;
                bool testDrugi = int.TryParse(prviBroj.ToString(), out drugi);
                if (testDrugi != true)
                {
                    return $"nemogu konvertirti u broj: {drugiBroj}";
                }
                int lokalniBrojJedan = Convert.ToInt32(prviBroj);
                int drugiLokalniBroj = Convert.ToInt32(prviBroj);

                return (lokalniBrojJedan + drugiLokalniBroj).ToString();
            }
        }

        [HttpGet("primjer-8")]
        public ActionResult<List<string>> ForachPrimjer()
        {
            //primjer kombinacije foreach petlje i if uvjeta
            //foreach petlja prebacuje imena iz jedne liste u drugu
            //i prebaciti će sve osim imena Pero jer smo rekli
            //da ako item nije jednak "Pero" tek onda dodajemo u listu
            //ako je item Pero, samo preskačemo taj item i nastavljamo vrtnju petlje do zadnjeg itema
            List<string> list = new List<string>()
            {"Pero","Marko","jure","Ivan" };

            List<string> vratiListu = new List<string>();
            foreach (var item in list)
            {
                if (item != "Pero")
                {
                    vratiListu.Add(item);
                }
            }
            return vratiListu;
        }
    }
}