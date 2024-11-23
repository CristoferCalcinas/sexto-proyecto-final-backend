namespace Libreria.PresentationLayer.ViewModels;

public class ProductoViewModel
{
    public int Id { get; set; }
    public string NombreProducto { get; set; } = null!;
    public string Descripción { get; set; } = null!;
    public decimal Precio { get; set; }
    public int CantidadStock { get; set; }
    public int CategoriaId { get; set; }
    public int ProveedorId { get; set; }
}