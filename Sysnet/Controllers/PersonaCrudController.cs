using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sysnet.Models;

namespace Sysnet.Controllers
{
    public class PersonaCrudController : ApiController
    {
        PersonaEntities per = new PersonaEntities();
        public IHttpActionResult getemp()
        {

            var results = per.Sp_Crud(0, "", "", "", "", "", "", "", "", "", "", DateTime.Now, "", "Get").ToList();
            return Ok(results);
        }

        public IHttpActionResult inseertemp(Persona perinsert)
        {
            var insertresults = per.Sp_Crud(0, perinsert.identificacion, perinsert.tipoIdentificacion, perinsert.primerApellido,
                perinsert.segundoApellido, perinsert.primerNombre, perinsert.segundoNombre, perinsert.direccion, perinsert.telefono,
                perinsert.email, perinsert.ocupacion, perinsert.fechaNacimiento, perinsert.foto,"Insert").ToList();
            return Ok(insertresults);
        }

        public IHttpActionResult getperid(int id)
        {
            var persdetails = per.Sp_Crud(id, "", "", "", "","","","","","","", DateTime.Now, "", "Getperid").Select(x => new PersonaClass()
            {
                id = x.id,
                identificacion = x.identificacion,
                tipoIdentificacion = x.tipoIdentificacion,
                primerApellido = x.primerApellido,
                segundoApellido = x.segundoApellido,
                primerNombre = x.primerNombre,
                segundoNombre = x.segundoNombre,
                direccion = x.direccion,
                telefono = x.telefono,
                email = x.email,
                ocupacion = x.ocupacion,
                fechaNacimiento = x.fechaNacimiento,
                foto = x.foto
            }).FirstOrDefault<PersonaClass>();
            return Ok(persdetails);
        }

        public IHttpActionResult put(PersonaClass pe)
        {
            var updateper = per.Sp_Crud(pe.id, pe.identificacion, pe.tipoIdentificacion,pe.primerApellido,pe.segundoApellido,
             pe.primerNombre,pe.segundoNombre,pe.direccion,pe.telefono,pe.email,pe.ocupacion,pe.fechaNacimiento,pe.foto,"Update").ToList();
            return Ok(updateper);
        }

        public IHttpActionResult Delete(int id)
        {
            var persdetails = per.Sp_Crud(id, "", "", "", "", "", "", "", "", "", "", DateTime.Now, "", "Delete").Select(x => new PersonaClass()
            {
                id = x.id,
                identificacion = x.identificacion,
                tipoIdentificacion = x.tipoIdentificacion,
                primerApellido = x.primerApellido,
                segundoApellido = x.segundoApellido,
                primerNombre = x.primerNombre,
                segundoNombre = x.segundoNombre,
                direccion = x.direccion,
                telefono = x.telefono,
                email = x.email,
                ocupacion = x.ocupacion,
                fechaNacimiento = x.fechaNacimiento,
                foto = x.foto
            }).FirstOrDefault<PersonaClass>();
            return Ok(persdetails);
        }

    }
}
