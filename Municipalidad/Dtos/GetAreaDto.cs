namespace Municipalidad.Abastecimiento.WebAPI.Dtos
{
    public class GetAreaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Encargado { get; set; } = null!;
    }
}
