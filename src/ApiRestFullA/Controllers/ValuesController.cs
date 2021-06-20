
using Microsoft.AspNetCore.Mvc;
using ApiRestFullA.inter;
using ApiRestFullA.Models;

namespace ApiRestFullA.Controllers
{
    [Route("Tlaloc/[controller]")]
    public class ValuesController : Controller
    {
        //[HttpGet("{id}")]
        [HttpGet("getCompany/{id}")]
        public IActionResult Get(string id)
        {
            DataSuin d = new DataSuin();
            Company c = d.getCompany(id);
            //return c;
            return Ok(c);
        }

        //[HttpPost("{setCompany}")]
        [HttpPost]
        //FromForm
        public IActionResult Post([FromBody] Company c) {
            response r = new response();
            int ti = 0;

            int b = 0;
            //string msj = "";

            if (c.IdentificationType == "" || c.IdentificationType == null) {
                b = 1;
                r.id = -1;
                r.msg = "Es necesrio el tipo de documento";
            }

            if (c.Identificationnumber == "" || c.Identificationnumber == null)
            {
                b = 1;
                r.id = -1;
                r.msg = r.msg + ", Es necesrio la identificacion";
            }

            if (c.Secondlastname == "" || c.Secondlastname == null)
            {
                b = 1;
                r.id = -1;
                r.msg = r.msg + ", Es necesrio el ultimo apellido";
            }
            if (c.Secondname == "" || c.Secondname == null)
            {
                b = 1;
                r.id = -1;
                r.msg = r.msg + ", Es necesrio el segundo nombre";
            }

            if (c.Firstname == "" || c.Firstname == null)
            {
                b = 1;
                r.id = -1;
                r.msg = r.msg + ", Es necesrio el primer nombre";
            }

            //if (c.Id == null) {
            //    c.Id = 0;
            //}
            if (c.email == null) {
                c.email = "";
            }

            if (b == 0)
            {

                DataSuin d = new DataSuin();
                if (c.Id != 0)
                {
                    ti = d.updateCompany(c);
                    r.msg = ti < 0 ? "Ocurrió un error al intentar Actualizar" : "Se actualizo correctamente";

                }
                else
                {
                    ti = d.insertCompany(c);
                    r.msg = ti < 0 ? "Ocurrió un error al intentar guardar" : "Se guardo correctamente";

                }

                r.id = ti;
            }

            return Ok(r);
        }

        [HttpGet("{getCompanys}")]
        public IActionResult Get() {
            DataSuin d = new DataSuin();
            return Ok(d.getCompanys());
        }
       
    }
}
