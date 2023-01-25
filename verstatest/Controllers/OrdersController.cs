using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using verstatest.Models;

namespace verstatest.Controllers
{
    public class OrdersController : Controller
    {
        private readonly verstatestContext _context;

        public OrdersController(verstatestContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }

        // GET: Orders/Details
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Order_ID == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Customer," +
                                                      "CargoWeight," +
                                                      "PickupDate,"+
                                                      "SendersAddress," +                                                                                                            
                                                      "DeliveryAddress"                                                      
                                                      )] Order order


                                                //[Bind("SendersAddress.Region," +
                                                //      "SendersAddress.City," +
                                                //      "SendersAddress.Details"
                                                //      )] Address sender,
                                                //[Bind("DeliveryAddress.Region," +
                                                //      "DeliveryAddress.City," +
                                                //      "DeliveryAddress.Details"
                                                //      )] Address delivery
                                                      )
        {
            //order.SendersAddress = sender;
            //order.DeliveryAddress = delivery;
            if (ModelState.IsValid)
            {                                                             
                _context!.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
            }                            
            return View(order);
        }
        private bool OrderExists(string id)
        {
          return (_context.Orders?.Any(e => e.Order_ID == id)).GetValueOrDefault();
        }
    }
}
