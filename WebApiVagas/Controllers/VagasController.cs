using FluentValidation;
using JsonPatch;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.OData;
using WebApiVagas.Models.Context;
using WebApiVagas.Models.Entities;
using WebApiVagas.Models.Validation;
using System.Web.Http.OData.Query;
using WebApiVagas.Filters;

namespace WebApiVagas.Controllers
{
    public class VagasController : ApiController
    {
        private VagasContext db = new VagasContext();
        private VagaValidator validador = new VagaValidator();

        // GET: api/Vagas
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Filter | AllowedQueryOptions.OrderBy | AllowedQueryOptions.Select | AllowedQueryOptions.Skip | AllowedQueryOptions.Top,
                     MaxTop = 10,
                     PageSize = 10)]
        public IQueryable GetVagas()
        {
            return db.Vagas.Where(v => v.Ativa);
        }

        // GET: api/Vagas/5
        public IHttpActionResult GetVaga(int id)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");

            Vaga vaga = db.Vagas.Find(id);

            if (vaga == null)
                return NotFound();

            return Ok(vaga);
        }

        // PUT: api/Vagas/5
        [BasicAuhtentication]
        public IHttpActionResult PutVaga(int id, Vaga vaga)
        {
            if(id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");

            if (id != vaga.Id)
                return BadRequest("O id informado na URL deve ser igual ao id informado no corpo da requisição.");

            if (db.Vagas.Count(v => v.Id == id) == 0)
                return NotFound();

            validador.ValidateAndThrow(vaga);

            var idsRequisitosEditados = vaga.Requisitos.Where(r => r.Id > 0).Select(r => r.Id);

            var requisitosExcluidos = db.Requisitos.Where(r => r.Vaga.Id == id && !idsRequisitosEditados.Contains(r.Id));

            db.Requisitos.RemoveRange(requisitosExcluidos);

            foreach (var requisito in vaga.Requisitos)
            {
                if (requisito.Id > 0)
                    db.Entry(requisito).State = EntityState.Modified;
                else
                    db.Entry(requisito).State = EntityState.Added;
            }

            db.Entry(vaga).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Vagas
        [BasicAuhtentication]
        public IHttpActionResult PostVaga(Vaga vaga)
        {
            validador.ValidateAndThrow(vaga);

            vaga.Ativa = true;

            db.Vagas.Add(vaga);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vaga.Id }, vaga);
        }

        // DELETE: api/Vagas/5
        [BasicAuhtentication]
        public IHttpActionResult DeleteVaga(int id)
        {
            if (id <= 0)
                return BadRequest("O id informado na URL deve ser maior que zero.");

            Vaga vaga = db.Vagas.Find(id);

            if (vaga == null)
                return NotFound();

            db.Vagas.Remove(vaga);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}