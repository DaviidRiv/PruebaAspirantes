using PruebaAspirantes.Models;
namespace PruebaAspirantes.Services
{
    public interface IService_API
    {
        Task<List<ModelAspirantes>> Lista();
        Task<ModelAspirantes> Obtener(int Id);

        Task<bool> Guardar(ModelAspirantes objeto);

        Task<bool> Editar(ModelAspirantes objeto);

        Task<bool> Eliminar(int Id);
    }
}
