namespace Municipalidad.Abastecimiento.WebAPI.Dtos
{
    public class GetProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string? Photo { get; set; }
    }
}
