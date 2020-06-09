using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Pattern.EF.EFCore;
using Repository.Pattern.EF.Entities;
using Repository.Pattern.EF.Repositories;

namespace Apis.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository Repository;
        private readonly IUnitOfWorks unitOfWork;

        public CategoriaController(ICategoriaRepository _Repository, IUnitOfWorks _unitOfWork)
        {           
            Repository = _Repository;
            unitOfWork = _unitOfWork;
        }

        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var item = await Repository.GetAll().ToListAsync();
                return Ok(item);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Find(int id)
        {
            try
            {
                var itemID = await Repository.GetById(id);
                if (itemID == null)
                    return BadRequest("El ID: " + id + " No existe, Vuela a ingresar otro ID.");
                var item = await Repository.GetById(id);
                return Ok(item);
            }
            catch
            {

                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("search/{keyword}")]
        public async Task<IActionResult> Search(string keyword)
        {
            try
            {
                var item = Repository.Search(keyword);
                return Ok(item);
            }
            catch
            {

                return BadRequest();
            }
        }


        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> Create(Categoria item)
        {
            var nombre = item.Nombre;
            var articuloEncontrado = Repository.Search(nombre);

            if (articuloEncontrado.Count > 0)
                return BadRequest("El articulo => " + nombre + " Ya existe en la base de datos.");
            try
            {
                await Repository.Create(item);
                await unitOfWork.CompleteAsync();
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPut]
        public async Task<IActionResult> Update(Categoria item)
        {
            try
            {
                var Itemid = await Repository.GetById(item.Id);
                if (Itemid == null)
                    return BadRequest("El ID: " + item.Id + " No existe, Vuela a ingresar otro ID.");
                await Repository.Update(item.Id, item);
                return Ok(item);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await Repository.GetById(id);
                if (item == null)
                    return BadRequest("El ID: " + id + " No existe, Vuela a ingresar otro ID.");

                await Repository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }




    }
}