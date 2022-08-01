namespace Municipalidad.Abastecimiento.WebAPI.Helpers
{
    public interface IAlmacenadorArchivos
    {
        Task<string> GuardarArchivo(string contenedor, IFormFile archivo);
        Task BorrarArchivo(string ruta, string contenedor);
        Task<string> EditarArchivo(string contenedor, IFormFile archivo, string ruta);
    }
}
