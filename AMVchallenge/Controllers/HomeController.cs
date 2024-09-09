using AMVchallenge.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class HomeController : Controller
{
    private readonly DB_AMVTRAVELcontext _context;

    public HomeController(DB_AMVTRAVELcontext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var toursConReservas = await _context.Tours
            .Include(t => t.Reservas)
            .ToListAsync();

        var usuario = HttpContext.Session.GetString("Usuario") ?? "UsuarioDesconocido";
        var model = new IndexViewModel
        {
            Usuario = usuario,
            Tours = toursConReservas
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AgregarTour(Tour tour)
    {
        _context.Tours.Add(tour);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> ReservarTour(int tourId)
    {
        var tour = await _context.Tours.FindAsync(tourId);
        if (tour != null)
        {
            var usuario = HttpContext.Session.GetString("Usuario") ?? "UsuarioDesconocido";
            var reserva = new Reserva
            {
                Cliente = usuario,
                TourId = tour.Id,
                FechaReserva = DateTime.Now
            };
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> EliminarReserva(int reservaId)
    {
        var reserva = await _context.Reservas.FindAsync(reservaId);
        if (reserva != null)
        {
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
}