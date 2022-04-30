using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_world_of_Disney.Comunes.data;
using The_world_of_Disney.Comunes.data.database;

namespace TheworldofDisney.Server.Controllers.DisneyControllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class PeliculaSerieControllers : ControllerBase
    {
        private readonly dbcontext context;

        public PeliculaSerieControllers(dbcontext context)
        {
            this.context = context;

        }

        [HttpGet]
        //metodo que me muestra la lista
        public async Task<IEnumerable<PeliculaSerie>> GetAll()//obtener todo All
        {
            List < PeliculaSerie > peliculas = await context.peliculaSeries.ToListAsync();
            //retorna la lista de la tabla 

            List<PeliculaSerie> Listado = new List<PeliculaSerie>();

            foreach (PeliculaSerie pelicula in peliculas)
            {
                Listado.Add(new PeliculaSerie
                {
                    Titulo = pelicula.Titulo,
                    Imagen = pelicula.Imagen,
                    Fechacreacion = pelicula.Fechacreacion
                });
            }
            return Listado; 
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PeliculaSerie>> Get(int id)
        {
            // await metodo a ejecutar asincronico
            PeliculaSerie peli = await context.peliculaSeries.Where(x => x.Id == id).FirstOrDefaultAsync();
            //x=>x.id x seria el registro delnde esta el id 
            if (peli == null)
            {
                return NotFound($"No existe el Personaje con id igual a {id}.");
            }
            return peli;
        }
        [HttpPost]
        public async Task<ActionResult<PeliculaSerie>> PostAsync(PeliculaSerie peli)//se el nombre del personaje pero 
                                                                              //no conozco el ID eso me lo da la base 
        {
            try
            {
                context.peliculaSeries.Add(peli);
                await context.SaveChangesAsync();
                return peli;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id:int}")] //modificacion de datos
        public async Task<ActionResult> Put(int id, [FromBody] PeliculaSerie peli)
        {

            //bsco un usuario de la clase estudiante de la tabla personaje x id

            PeliculaSerie peliserieencontrada = await context.peliculaSeries.Where(x => x.Id == id).FirstOrDefaultAsync();
            //si mi id es null no existe 
            if (peliserieencontrada == null)
            {
                return NotFound("no existe el estudiante a modificar.");
            }
            //si es correcto puedo modificar todo lo q sigue
            peliserieencontrada.Id = peli.Id;
            peliserieencontrada.Imagen = peli.Imagen;
            peliserieencontrada.Titulo = peli.Titulo;
            peliserieencontrada.Fechacreacion = peli.Fechacreacion;
            peliserieencontrada.calificacion = peli.calificacion;
            peliserieencontrada.PersonajeAsociado = peli.PersonajeAsociado;

            try
            {
                context.peliculaSeries.Update(peliserieencontrada);
                await context.SaveChangesAsync();
                return Ok("Los datos han sido cambiados");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id:int}")]//metodo borrar 
        public async Task<ActionResult> Delete(int id)
        {
            //await metodo asincronoico
            if (id <= 0)
            {
                return BadRequest("No es correcto");
            }
            PeliculaSerie peli = await context.peliculaSeries.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (peli == null)//parametro de q no puede ser nulo el dato
            {
                return NotFound($"No existe el personaje con id igual a {id}.");//retorna error
            }
            //try uso de excepcion ya que en la ejecuc  ion hubo un error en el id del estudiante y se desea que siga
            //ejecutandose por lo q el uso correcto es el try catch
            try
            {
                context.peliculaSeries.Remove(peli);//borrar estudiante de la table alumno
                await context.SaveChangesAsync();//busca el dato guardado
                return Ok($"la pelicua o serie  {peli.Titulo} ha sido borrado.");//retorna q se borro
            }
            catch (Exception) //se captura la excepcion del try
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }

        }

    } 
}
