using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketOnline.Data;
using TicketOnline.Model;

namespace TicketOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TicketsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(string id)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        // PUT: api/Tickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutTicket(string id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
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

        // POST: api/Tickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("placeOrder"), Authorize]
        public async Task<IActionResult> PostTicket(PlaceOrder ticket)
        {
            SqlMoney money = 0;
            var a = HttpContext.Request.Cookies["customerid"];
            Order order = new Order() {
                CustomerId = a,
                Status = false,
                Total = 0};
            _context.Orders.Add(order);
            TicketOrder ticketadd = ticket.Tickets;
            var showtime = _context.ShowTimes.Find(ticketadd.ShowTimeId);
            foreach(var item in ticketadd.Tickets)
            {
                var seat = _context.Seats.First(s => (s.SeatNumber == Int16.Parse(item.SeatNumber)) && (s.RowName == char.Parse(item.SeatRow)) && (s.RoomNumberId == showtime.RoomNumberId));
                Ticket ticket1 = new Ticket()
                {
                    OrderId = order.Id,
                    SeatId = seat.Id,
                    ShowtimeId = ticketadd.ShowTimeId,
                };
                money += ticket1.Price;
                _context.Tickets.Add(ticket1);
            }
            if(ticket.Products != null)
            foreach(var item in ticket.Products)
            {
                OrderItem orderItem = new OrderItem()
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };
                    var product = _context.Products.FirstOrDefault(p => p.Id == item.ProductId);
                    money += product.Price * orderItem.Quantity;
                _context.OrderItems.Add(orderItem);
            }
            order.Total = (decimal)money;
            await _context.SaveChangesAsync();
            return Ok(order.Id);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTicket(string id)
        {
            var a = HttpContext.Request.Cookies["customerid"];
            return Ok(a);
        }

        private bool TicketExists(string id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
        [HttpGet("order/{orderid}")]
        public IEnumerable<Ticket> GetTicketsByOrderId(string orderId)
        {
            return _context.Tickets.Where(t => t.OrderId == orderId).ToList();
        }
    }
}
