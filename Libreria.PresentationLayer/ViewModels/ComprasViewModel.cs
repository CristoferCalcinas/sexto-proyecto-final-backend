namespace Libreria.PresentationLayer.ViewModels;

public class ComprasViewModel
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public string Estado { get; set; } = null!;

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }
}
