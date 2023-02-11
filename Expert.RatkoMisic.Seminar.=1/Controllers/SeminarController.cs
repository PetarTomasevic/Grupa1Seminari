using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Expert.RatkoMisic.Seminar._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeminarController : ControllerBase
    {
        //Seminar zadatak 1
        [HttpGet("zadatak_Prvi/{imePrezime}")]
        public ActionResult<string> zadatakPrvi(string imePrezime)
        {
            return $"Seminar napravio: {imePrezime}";
        }

        //Seminar zadatak 2
        [HttpGet("zadatak_Drugi/{prviBroj}/{drugiBroj}")]
        public ActionResult<int> zadatakDrugi(int prviBroj, int drugiBroj)
        {
            return prviBroj + drugiBroj;
        }

        //Seminar zadatak 3
        [HttpGet("zadatak_Treci/{prviBroj}/{drugiBroj")]
        public ActionResult<string> zadatakTreci(int prviBroj, int drugiBroj)
        {
            return $"Rezultat dva proslijedjena broja je: {prviBroj + drugiBroj}";
        }

        //Seminar zadatak 4

        [HttpGet("zadatak_Cetvrti/{prviBroj}/{drugiBroj}")]
        public ActionResult<int> zadatakCetvrti(int prviBroj, int drugiBroj)
        {
            if (prviBroj > drugiBroj)
            {
                return prviBroj;
            }

            else
            {
                return drugiBroj;
            }

           

            

         












        }
        //Seminar zadatak 5

        [HttpGet ("zadatak-Pet/{prviBroj}/{drugiBroj}")]
        public ActionResult<int>zadatakPet(string prviBroj, string drugiBroj)
        {
            int broj1 = Convert.ToInt32(prviBroj);
            int broj2 = Convert.ToInt32(drugiBroj);

            if (broj1 < broj2)
            {
                return broj1 + broj2;
            }
            else if (broj1 == broj2)
            {
                return broj1 * broj2;
            }
            else
            {
                return broj2 - broj1;
            }
        }

        
        

        

        //Seminar zadatak 6

        [HttpGet("zadatak_Sesti/{odabraniBroj}")]

        public ActionResult<List<string>> zadatak_Sesti(int odabraniBroj)
        {
            List<string> interacija = new List<string>();
            for (int i = 1; i <= 10; i++)
            {
                interacija.Add("rezultat {i}. interacije je:{i * odabraniBroj}");
            }
            return interacija;
        }

















    }
}
                

                

            
            
            


            
         
            
            
            




           

            
            
              
            
        
        
    

