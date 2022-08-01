namespace Municipalidad.Abastecimiento.WebAPI.Dtos
{
    public class ProductoCreacionDto
    {
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int Cantidad { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
