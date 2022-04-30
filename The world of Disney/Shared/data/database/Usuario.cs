using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_world_of_Disney.Comunes.data.database
{
    [Index(nameof(Id), Name = "UQ_Usuario_Id", IsUnique = true)]
    public class Usuario
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "El Username es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El Email es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El Lastname es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "El Pasword es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string Pasword { get; set; }
        public Nullable<int> Token { get; set; }
        

        
    }
}
