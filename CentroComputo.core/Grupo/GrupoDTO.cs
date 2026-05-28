using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CentroComputoDTOS
{
    public class GrupoSetDTO
    {
        [Required] public int IDgeneracion { get; set; }
        [Required, StringLength(12)] public string Nombre { get; set; } = string.Empty;
    }

    public class GrupoGetDTO
        {
        [Key] public int ID { get; set; }
        [Required] public int IDgeneracion { get; set; }
        public string NombreGeneracion { get; set; }
        [Required, StringLength(12)] public string Nombre { get; set; } = string.Empty;
    }
}
