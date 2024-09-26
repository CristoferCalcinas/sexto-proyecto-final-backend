using System;
using System.Collections.Generic;

namespace Libreria.DataAccessLayer.DataContext;

public partial class Categoría
{
    public int Id { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
