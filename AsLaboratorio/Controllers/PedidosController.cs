using GerenciadorPedidos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorClientes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        private static List<Pedido> pedidos = new List<Pedido>();
        private static int nextId = 1;

        
        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> GetClientes()
        {
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public ActionResult<Pedido> GetCliente(int id)
        {
            var pedido = pedidos.Find(c => c.Id == id);
            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        
        [HttpPost]
        public ActionResult<Pedido> CreateCliente(Pedido pedido)
        {
            pedido.Id = nextId++;
            pedidos.Add(pedido);
            return CreatedAtAction(nameof(GetCliente), new { id = pedido.Id }, pedido);
        }

        
        [HttpPut("{id}")]
        public ActionResult UpdateCliente(int id, Pedido pedidoAtualizado)
        {
            var pedido = pedidos.Find(c => c.Id == id);
            if (pedido == null)
                return NotFound();

            pedido.Id = pedidoAtualizado.Id;
            pedido.Data = pedidoAtualizado.Data;
            pedido.ValorTotal = pedidoAtualizado.ValorTotal;
            pedido.Status = pedidoAtualizado.Status;
            pedido.Descricao = pedidoAtualizado.Descricao;

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public ActionResult DeleteCliente(int id)
        {
            var pedido = pedidos.Find(c => c.Id == id);
            if (pedido == null)
                return NotFound();

            pedidos.Remove(pedido);
            return NoContent();
        }
    }
}