using System.ComponentModel.DataAnnotations.Schema;

public class Tour
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Destino { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public decimal Precio { get; set; }
    public ICollection<Reserva> Reservas { get; set; }

    [NotMapped]
    public bool TieneReservas => Reservas != null && Reservas.Any();
}

public class IndexViewModel
{
    public string Usuario { get; set; }
    public List<Tour> Tours { get; set; }
}