using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _1998YIUL0801199901278.Models;
using _1998YIUL0801199901278.Models.Request;
using _1998YIUL0801199901278.Models.Response;

namespace _1998YIUL0801199901278.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentumsController : ControllerBase
    {
        private readonly AtlantidaContext _context;

        public CuentumsController(AtlantidaContext context)
        {
            _context = context;
        }

        // GET: api/Cuentums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuentum>>> GetCuenta()
        {
            return await _context.Cuenta.ToListAsync();
        }

        // GET: api/Cuentums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuentum>> GetCuentum(int id)
        {
            var cuentum = await _context.Cuenta.FindAsync(id);

            if (cuentum == null)
            {
                return NotFound();
            }

            return cuentum;
        }

        // PUT: api/Cuentums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuentum(int id, Cuentum cuentum)
        {
            if (id != cuentum.Id)
            {
                return BadRequest();
            }

            _context.Entry(cuentum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuentumExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPut("deposito/{id}")]
        public async Task<IActionResult> Deposito(int id, Cuentum cuentum)
        {
            Respuesta respuesta = new Respuesta();
            var GetCuentasBloqueada = _context.Cuenta.Any(x => x.Id == id && x.CodigoEstado==2);

            if (GetCuentasBloqueada)
            {
                return Content("Cuenta se encuentra bloqueada");
               
            }
            else
            {
                try
                {
                    respuesta.Exito = 1;
                    Cuentum cuentum1 = _context.Cuenta.Find(id);
                    cuentum1.Saldo = cuentum1.Saldo + cuentum.Saldo;
                    respuesta.Mensaje = "Deposito realizado correctamente";

                    _context.SaveChanges();

                }
                catch (Exception ex)
                {
                    respuesta.Mensaje = ex.Message;
                }

                return Ok(respuesta);

            }

           
        }

        [HttpPut("retiro/{id}")]
        public async Task<IActionResult> Retiro(int id, Cuentum cuentum)
        {

            var Lempiras = 100;
            var Dolares = 5;
            Respuesta respuesta = new Respuesta();
            var GetCuentasBloqueada = _context.Cuenta.Any(x => x.Id == id && x.CodigoEstado == 2);
            var getTipoCuenta = _context.Cuenta.Any(x => x.TipoCuenta == cuentum.TipoCuenta && x.Id == id);
            if (GetCuentasBloqueada)
            {
                return Content("Cuenta se encuentra bloqueada");

            }
            else
            {
                try
                {
                    respuesta.Exito = 1;
                    Cuentum cuentum1 = _context.Cuenta.Find(id);
                    cuentum1.Saldo = cuentum1.Saldo - cuentum.Saldo;
                    respuesta.Mensaje = "Retiro realizado correctamente";

                    if(cuentum1.TipoCuenta==1 && cuentum1.Saldo < Lempiras) {
                        cuentum1.CodigoEstado = 2;
                    }
                    else
                    if(cuentum1.TipoCuenta == 2 && cuentum1.Saldo < Dolares)
                    {
                        cuentum1.CodigoEstado = 2;
                    }

                    _context.SaveChanges();

                }
                catch (Exception ex)
                {
                    respuesta.Mensaje = ex.Message;
                }

                return Ok(respuesta);

            }


        }

        // POST: api/Cuentums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
    /*    public async Task<ActionResult<Cuentum>> PostCuentum(Cuentum cuentum)
        {
            _context.Cuenta.Add(cuentum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCuentum", new { id = cuentum.Id }, cuentum);
        }*/

        public IActionResult crearCuenta(CuentaRequest cuentaRequest)
        {

            var Lempiras = 200;
            var dolar = 10;
            Respuesta respuesta = new Respuesta();
            var EstadoActivo = 1;

            var cliente = _context.Clientes.Find(cuentaRequest.CodigoCliente);
            var existeClienteConcuenta = _context.Cuenta.Any(x => x.CodigoCliente == cuentaRequest.CodigoCliente && x.TipoCuenta==cuentaRequest.TipoCuenta);
            //ar estadoCliente = _context.Clientes.Any(x => x.Id == cuentaRequest.CodigoCliente && x.CodigoEstado== EstadoActivo);
          
            if (cliente==null)
            {
                return Content("Cliente no existe");
            }
            else
            if (cliente.CodigoEstado != EstadoActivo)
            {
                return Content("Cliente no se encuentra activo");
            }
            else
            if (existeClienteConcuenta)
            {
                return Content("Cliente ya existe con esta cuenta");
            }
            else
            if(cuentaRequest.TipoCuenta==1 && cuentaRequest.Saldo < 200)
            {
                return Content("Cuenta de ahorro debe ser mayor o igual a LPS.200.00 ");
            }else
            if(cuentaRequest.TipoCuenta==2 && cuentaRequest.Saldo < 10)
            {
                return Content("Cuenta de cheques debe ser mayor o igual a $10.00 ");
            }

            
            else {
               
                try
                {
                    Cuentum cuenta = new Cuentum();
                    cuenta.CodigoCliente = cuentaRequest.CodigoCliente;
                    cuenta.TipoCuenta = cuentaRequest.TipoCuenta;
                    cuenta.TipoMondea = cuentaRequest.TipoMondea;
                    cuenta.Saldo = cuentaRequest.Saldo;
                    cuenta.CodigoEstado = cuentaRequest.CodigoEstado;
                    respuesta.Exito = 1;
                    respuesta.Mensaje = "Registro realizado correctamente";
                  
                    _context.Cuenta.Add(cuenta);
                    _context.SaveChanges();
                   
                }
                catch (Exception ex)
                {

                    respuesta.Mensaje = ex.Message;
                }
                return Ok(respuesta);

            }
          
        }
       
        // DELETE: api/Cuentums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuentum(int id)
        {
            Respuesta respuesta = new Respuesta();

            var existe = _context.Cuenta.Any(x => x.Id == id);

            if (existe)
            {

                try{

                    Cuentum cuentum = _context.Cuenta.Find(id);
                    _context.Remove(cuentum);
                    _context.SaveChanges();
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

        private bool CuentumExists(int id)
        {
            return _context.Cuenta.Any(e => e.Id == id);
        }
    }
}
