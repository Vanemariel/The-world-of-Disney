using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace The_world_of_Disney.Comunes.data.database
{
    [Index(nameof(Id), Name = "UQ_Personaje_Id", IsUnique = true)]
    public class Personaje
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La imagen es obligatoria.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string Imagen { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "La historia es obligatoria.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string Historia { get; set; }

        [Required(ErrorMessage = "El Nombre del personaje es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El peso del personaje es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string Peso { get; set; }

        [Required(ErrorMessage = "El Nombre de peliculasseriesasociadas es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string PeliculasSeriesAsociadas { get; set; }

        public List<PeliculaSerie> peliculaSeries { get; set; }

    }
}