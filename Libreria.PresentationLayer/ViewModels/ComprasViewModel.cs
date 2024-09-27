namespace Libreria.PresentationLayer.ViewModels;

public class ComprasViewModel
{
    public int Id { get; set; }

    public DateOnly FechaCompra { get; set; }

    public int ClienteId { get; set; }

    public decimal TotalCompra { get; set; }

    public string Estado { get; set; } = null!;
}
