using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Expert.DinoKabalin.Seminar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeminarController : ControllerBase
    {
        //Seminar - zadatak - 1 - POČINJE
        [HttpGet("zadatak-Jedan/{imePrezime}")]
        public ActionResult<string>zadatakJedan(string imePrezime)
        {
            return $"Seminar napravio: {imePrezime}";
        }
        //Seminar - zadatak - 1 - ZAVRŠAVA
 


        //Seminar - zadatak - 2 - POČINJE
        [HttpGet("zadatak-dva/{prviBroj}/{drugiBroj}")]
        public ActionResult<int> zadatakDva(int prviBroj, int drugiBroj)
        {
            return prviBroj + drugiBroj;
        }
        //Seminar - zadatak - 2 - ZAVRŠAVA



        //Seminar - zadatak - 3 - POČINJE
        [HttpGet("zadatak-tri/{prviBroj}/{drugiBroj}")]
        public ActionResult<string> zadatakTri(int prviBroj, int drugiBroj)
        {
            return $"Rezultat dva proslijeđena broja je: {prviBroj + drugiBroj}";
        }
        //Seminar - zadatak - 3 - ZAVRŠAVA



        //Seminar - zadatak - 4 - POČINJE
        [HttpGet("zadatak-cetiri/{prviBroj}/{drugiBroj}")]
        public ActionResult<int> zadatakCetiri(int prviBroj, int drugiBroj)
        {
            if (prviBroj > drugiBroj)
            {
                return prviBroj;
            }

            else
            {
                return drugiBroj;
            }
        } //Seminar - zadatak - 4 - ZAVRŠAVA



        //Seminar - zadatak - 5 - POČINJE
        [HttpGet("zadatak-pet/{prviBroj}/{drugiBroj}")]
        public ActionResult<int> zadatakPet(string prviBroj, string drugiBroj)
        {
            int broj1=Convert.ToInt32(prviBroj);
            int broj2=Convert.ToInt32(drugiBroj);

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

        } //Seminar - zadatak - 5 - ZAVRŠAVA


        //Seminar - zadatak - 6 - POČINJE
        [HttpGet("zadatak-sest/{odabraniBroj}")]
        public ActionResult<List<string>> zadatakSest(int odabraniBroj)
        {
            List<string> iteracija = new List<string>();
            for (int i = 1; i <= 10; i++)
            {
                iteracija.Add($"Rezultat {i} .iteracije je: {i * odabraniBroj}");
            }
            return iteracija;

        } //Seminar - zadatak - 6 - ZAVRŠAVA

    }
}
