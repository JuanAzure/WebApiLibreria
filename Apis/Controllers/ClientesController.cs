using Apis.Models;
using AutoMapper;
using Library.Repo.SqlServer.DBModelCliente;
using Library.Repo.SqlServer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apis.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClientesRepository _clientesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClientesController(IMapper mapper,
                                  IClientesRepository clientesRepository,
                                  IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._clientesRepository = clientesRepository;
            this._unitOfWork = unitOfWork;
        }

        //[Authorize]
        [HttpGet]
        [Route("lista")]
        public async Task<IActionResult> Lista()
        {
            try
            {
                var clientes = await _clientesRepository.ObtenerClientes();
                var retClientes = _mapper.Map<IQueryable<Clientes>,IEnumerable<MCliente>>(clientes);

                return Ok(retClientes);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [Route("actualizar")]
        [HttpPut]
        public async Task<IActionResult> Actualizar(MCliente clienteCRUD )
        {
            try
            {
                Clientes clienteDB = await _clientesRepository.ObtenerClienteIdAsync(clienteCRUD.Id);
                if (clienteDB==null)
                {
                    return BadRequest("El cliente no existe.");
                }

                _mapper.Map(clienteCRUD, clienteDB);
                await _unitOfWork.CompleteAsync();
                var result = _mapper.Map<Clientes, MCliente>(clienteDB);
                return Ok(result);
            }

            catch (Exception e)
            {
                return StatusCode(500, e);                
            }            
        }

        //[HttpPost]
        //[Route("agregar")]
        //public async Task<IActionResult> AgregarCliente(MCliente cli)
        //{
        //    try
        //    {
        //        var clieAgregar = _mapper.Map<MCliente,Clientes>(cli);

        //        await _clientesRepository.AgregarClienteAsync(clieAgregar);

        //        await _unitOfWork.CompleteAsync();
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e);
        //    }
        //}


        [HttpPost]
        [Route("agregar")]        
        public async Task<IActionResult> AgregarCliente(MCliente cli)
        {
            try
            {
                var cliAgregar = _mapper.Map<MCliente, Clientes>(cli);

                await _clientesRepository.AgregarClienteAsync(cliAgregar);
                await _unitOfWork.CompleteAsync();

                return Ok();
            }
            catch (Exception e)
            {
                
                return StatusCode(500, e);
            }
        }

        
        [HttpDelete]
        [Route("eliminar/{id}")]
        public async Task<IActionResult> EliminarCliente(int id)
        {
            try
            {
                // Recuperamos el cliente de la base
                Clientes clienteDB = await _clientesRepository.ObtenerClienteIdAsync(id);

                if (clienteDB == null)
                {
                    return NotFound("El cliente no existe");
                }
                _clientesRepository.EliminarCliente(clienteDB);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch (Exception e)
            {                
                return StatusCode(500, e);
            }
        }
    }
}