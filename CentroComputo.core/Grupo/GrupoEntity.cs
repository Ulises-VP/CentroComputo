using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EIN.Entidades
{
    [Table("Grupo")]
    public class GrupoEntity
    {
        [Key] public int ID {  get; set; }
        [Required]public int IDgeneracion { get; set; }
        [Required, StringLength(12)] public string Nombre { get; set; } = string.Empty;
        [Required]public bool EstarActivo { get; set; }

        [ForeignKey("IDgeneracion")]public virtual required GeneracionEntity Generacion { get; set; }
    }
}
