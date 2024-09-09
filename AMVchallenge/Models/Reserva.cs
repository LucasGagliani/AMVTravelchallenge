using System.ComponentModel.DataAnnotations;

public class Reserva
{
    [Key]
    public int Id { get; set; }
    public string Cliente { get; set; }
    public DateTime FechaReserva { get; set; }
    public int TourId { get; set; } 

}