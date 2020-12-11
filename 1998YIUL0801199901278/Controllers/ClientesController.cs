using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _1998YIUL0801199901278.Models;
using _1998YIUL0801199901278.Models.Response;
using _1998YIUL0801199901278.Models.Request;

namespace _1998YIUL0801199901278.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AtlantidaContext _context;

        public ClientesController(AtlantidaContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
       /* public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }*/

        public IActionResult get()
        {

            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta.Exito = 1;
                var lst = _context.Clientes.ToList();
                respuesta.Data = lst;
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
           

            return Ok(respuesta);
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
       /* public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }*/

        public IActionResult getCliente(int id)
        {

            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta.Exito = 1;
                Cliente cliente = _context.Clientes.Find(id);
                respuesta.Data = cliente;
                respuesta.Mensaje = "Exito";
                    
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }


            return Ok(respuesta);
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id,ClienteRequest clienteRequest)
        {

            var existe = _context.Clientes.Any(x=>x.Id== id);
            Respuesta res = new Respuesta();

            try
            {
                Cliente cliente1 = _context.Clientes.Find(id);
                res.Mensaje = "Transaccion realizada correctamente";
                cliente1.PrimerN = clienteRequest.PrimerN;
                cliente1.SegundoN = clienteRequest.SegundoN;
                cliente1.PrimerA = clienteRequest.PrimerA;
                cliente1.SegundoA = clienteRequest.SegundoA;
                cliente1.Direccion = clienteRequest.Direccion;
                cliente1.FechaNacimiento = clienteRequest.FechaNacimiento;
                cliente1.Identidad = clienteRequest.Identidad;
                cliente1.Genero = clienteRequest.Genero;
                cliente1.id_ciudad = clienteRequest.id_ciudad;
                cliente1.IdProfesion = clienteRequest.IdProfesion;
                cliente1.CodigoEstado = clienteRequest.CodigoEstado;
                res.Exito = 1;
                res.Data = cliente1;

                _context.Entry(cliente1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

            }
            catch(Exception ex)
            {
                res.Mensaje = ex.Message;

            }

            return Ok(res);
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
     /*   public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }*/



        public IActionResult Crear(Cliente request)
        {
            if (IdentidadExiste(request.Identidad))
            {
                return Content("Usuario ya exite");
            }
            else { 


            Respuesta respuesta = new Respuesta();
            try
            {
                Cliente cliente = new Cliente();
                cliente.PrimerN = request.PrimerN;
                cliente.SegundoN = request.SegundoN;
                cliente.PrimerA = request.PrimerA;
                cliente.SegundoA = request.SegundoA;
                cliente.Direccion = request.Direccion;
                cliente.FechaNacimiento = request.FechaNacimiento;
                cliente.Identidad = request.Identidad;
                cliente.Genero = request.Genero;
                cliente.id_ciudad = request.id_ciudad;
                cliente.IdProfesion = request.IdProfesion;
                cliente.CodigoEstado = request.CodigoEstado;
                respuesta.Exito = 1;
              
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }


            return Ok(respuesta);
            }

        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            Respuesta respuesta = new Respuesta();
            var exite = _context.Clientes.Any(x => x.Id == id);

            if (exite) {
                try
                {
                    Cliente cliente = _context.Clientes.Find(id);



                    _context.Remove(cliente);
                    _context.SaveChanges();
                    respuesta.Mensaje = "Transaccion realizada correctamente";


                }
                catch (Exception ex)
                {
                    respuesta.Mensaje = ex.Message;

                }

                return Ok(respuesta);

            }
            else
            {
                return Content("No existe ese registro");
            }
           
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }

        private bool IdentidadExiste(string identidad)
        {
            return _context.Clientes.Any(x => x.Identidad == identidad);
        }
    }
}
