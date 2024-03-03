using Core.Entities.Producto;

namespace WebApi.DTOs.Items
{
    public class ItemGrupoDTO
    {
        public int? Numero { get; set; }
        public string NombreGrupo { get; set; }
    }

    public class MapeoItemGroup
    {
        public static ItemGrupoDTO MapToDTO(ItemGroup data)
        {
            return new ItemGrupoDTO
            {
                Numero = data.Number,
                NombreGrupo = data.GroupName
            };
        }
    }
}
