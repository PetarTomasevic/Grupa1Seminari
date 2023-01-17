using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.ComponentModel;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DomagojŠvec.seminar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeminarController : ControllerBase
    {



        //Napravi get Metodu koja prihvaća imePrezime parametar tipa string, i vraća rezultat tipa string i u kojem će pisati "Seminar napravio: {imePrezime}" 

        [HttpGet("vrati/{imePrezime}")]
        public ActionResult<string> vrati(string imePrezime)
        {
            var vracenstring = $"Seminar napravio" + imePrezime;
            return vracenstring;
        }





        //Napravi Get metodu koja će prihvaćati 2 parametra tipa int, te vratiti zbroj bilo koja 2 broja koji će se proslijediti kroz ta dva parametra

        [HttpGet("zbroji-dva-broja/{prviBroj}/{drugiBroj})")]
        public ActionResult<int> zbroji(int prviBroj, int drugiBroj)
        {
            var zbroj = prviBroj + drugiBroj;
            return zbroj;
        }




        //Napravi Get metodu koja će primiti dva parametra tipa int , zbrojiti ta dva broja i vratiti rezultat tipa string u kojem će pisati "Rezultat dva proslijeđena broja je: {rezultat}"}"

        [HttpGet("zbrojidvastringa/{treciBroj}/{cetvrtiBroj}")]
        public ActionResult<string> usporedi(int treciBroj, int cetvrtiBroj)
        {
            var Zbroj = $"Rezultat dva prosljeđenaj broja je:" + treciBroj + cetvrtiBroj;


            return Zbroj.ToString();

        }
        //Napravi get Metodu koja će primiti 2 parametra tipa int , te sa IF uvjetom provjeriti da li je prvi broj veći od drugoga.
	     //-Ako je prvi dobijeni broj veći od drugog vrati kao rezultat prvi broj, u suprotnom vrati drugi broj kao rezultat.
        
        [HttpGet("usporedidvaparametra/{prviparametar}/{drugiparametar}")]
        public ActionResult<int> usporedba(int prviparametar, int drugiparametar)
        {


            if (prviparametar > drugiparametar) 
            { 
             
            return prviparametar;

             }

            else
            {
                return drugiparametar;
            
            }

        }

        // Napravi get metodu koja će primiti 2 broja tipa string. Konvertiraj ih u integer i napravi sljedeće provjere:
        // -ako je prvi broj manji od drugoga - zbroji ta ta dva broja i vrati rezultat
        // - ako je prvi broj jednak drugom -pomnoži ta dva broja i vrati rezultat
        //  -u suprotnom oduzmi drugi broj od prvog i vrati rezultat

        [HttpGet("zbroji-pretvori-dva-stringa/{prvistring}/{drugistring}")]
        public ActionResult<int> pretvori(string prvistring, string drugistring)
        {
            int prviinteger = Convert.ToInt32(prvistring);
            int drugiinteger = Convert.ToInt32(drugistring);

            if (prviinteger < drugiinteger)
            {
                return prviinteger + drugiinteger;

            }

            
            else if (prviinteger == drugiinteger)
            {
                return prviinteger * drugiinteger;
            }

            
            
            else 
                   
             {
                return drugiinteger - prviinteger;
             }
        }


        //Napravi Get metodu koja prima  parametar {odabraniBroj} tipa int.
        //-u svakoj iteraciji petlje pomnozi {i} vrijednost petlje sa prosliijeđenom vrijednosti odabraniBroj(i* odabraniBroj)
        //-vrati listu stringova sa 10 rezultata na način da String izgleda ovako "rezultat {i}. iteracije je {rezultatMnozenja}"

        [HttpGet ("primi-broj/odabranibroj")]
       public ActionResult 








        // POST api/<SeminarController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SeminarController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SeminarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
