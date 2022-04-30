using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_world_of_Disney.Comunes.data.database
{
    [Index(nameof(Id), Name = "UQ_Genero_Id", IsUnique = true)]
    public class Genero
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "el nombre del genero es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "la pelicila o serie asociado es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string PeliculaSerieAsociada { get; set; }
        public string Imagen { get; set; }
    }
}
