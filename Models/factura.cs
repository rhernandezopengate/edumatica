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
    using System.Collections.Generic;
    
    public partial class factura
    {
        public int id { get; set; }
        public string NumeroFactura { get; set; }
        public Nullable<System.DateTime> FechaFactura { get; set; }
        public Nullable<System.DateTime> FechaSello { get; set; }
        public Nullable<System.DateTime> FechaVencimiento { get; set; }
        public Nullable<System.DateTime> FechaPago { get; set; }
        public string Concepto { get; set; }
        public Nullable<int> DiasVencidos { get; set; }
        public string Observaciones { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public Nullable<decimal> Subtotal { get; set; }
        public Nullable<decimal> Iva { get; set; }
        public Nullable<decimal> Descuento { get; set; }
        public Nullable<decimal> Total { get; set; }
        public int Proveedor_Id { get; set; }
        public int EstadoFactura_Id { get; set; }
        public string UserId { get; set; }
        public Nullable<decimal> Retencion { get; set; }
    
        public virtual estadofactura estadofactura { get; set; }
        public virtual proveedor proveedor { get; set; }
    }
}
