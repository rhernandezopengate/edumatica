//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OpenGateLogistics.Models
{
    using System;
    
    public partial class SP_BUSQUEDA_PROVEEDORES_Result
    {
        public int id { get; set; }
        public string RazonSocial { get; set; }
        public string RFC { get; set; }
        public int CategoriaProveedor_Id { get; set; }
        public int NacionalidadProveedor_Id { get; set; }
        public int EstadoProveedor_Id { get; set; }
        public string Categoria { get; set; }
        public string Nacionalidad { get; set; }
        public string Estado { get; set; }
    }
}
