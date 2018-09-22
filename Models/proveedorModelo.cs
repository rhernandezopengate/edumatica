using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpenGateLogistics.Models
{
    public class proveedorModelo
    {
        [Required]
        [Display(Name = "Razon Social")]
        public string  RazonSocial { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }
    }

    [MetadataType(typeof(proveedorModelo))]
    public partial class proveedor
    {
        [Display(Name = "Estado")]
        public string Estado { get; set; }
    }
}