using EIN.Enumeradores;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EIN.Entidades
{
    public class AlumnoEntity
    {

        [Key] public int ID { get; set; }
        [Required, StringLength(10)] public string NoCuenta { get; set; } = string.Empty;
        [Required, StringLength(30)] public string Nombre { get; set; } = string.Empty;
        [Required, StringLength(30)] public string ApellidoPA { get; set; } = string.Empty;
        [Required, StringLength(30)] public string ApellidoMA { get; set; } = string.Empty;
        [Required, StringLength(10)] public string Telefono { get; set; } = string.Empty;
        public SexoEnum Sexo { get; set; }
        public int IDgrupo {  get; set; }
        public bool EstaActivo { get; set; }

        [ForeignKey("IDgrupo")] public virtual GrupoEntity Grupo { get; set; }
    }
}
