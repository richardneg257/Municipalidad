namespace Municipalidad.Abastecimiento.WebAPI.Dtos
{
    public class GetProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
    }
}
