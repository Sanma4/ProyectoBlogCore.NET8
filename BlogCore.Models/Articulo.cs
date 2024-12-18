using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.Models
{
    public class Articulo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        [Display(Name = "Nombre del Artículo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La Descripción es requerida")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha de creación")]
        public string FechaCreacion { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }

        [Required(ErrorMessage = "La Categoría es requerida")]
        public int CategoriaId { get; set; }

        [ForeignKey(nameof(CategoriaId))]
        public Categoria Categoria { get; set; }
    }
}
