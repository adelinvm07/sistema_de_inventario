namespace SistemaInventario.Entidades;

public abstract class ClaseBase
{
    public int Id { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public DateTime FechaModificacion { get; set; } = DateTime.Now;
    public bool Activo { get; set; } = true;
}
