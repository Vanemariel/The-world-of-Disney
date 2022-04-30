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
    public class PersonajesControllers : ControllerBase
    {
        private readonly dbcontext context;

        public PersonajesControllers(dbcontext context)
        {
            this.context = context;
        }

       // [HttpGet]
        //metodo que me muestra la lista- get
        /*public async Task<ActionResult<List<Personaje>>> Get()//obtener todo 
        {
            return await context.personajes.Include(x => x.peliculaSeries).ToListAsync();
            //return new List<Personajes>();
            //awai metodo asincronico
            //retorna la lista de la clase personaje e incluye la de peliculasseries

        }*/

        [HttpGet]
        //metodo que me muestra la lista- getAll
        public async Task<ActionResult<List<Personaje>>> GetAll(string Nombre, string Edad, string PeliculaSeries)//obtener todo All
        {
            return await context.personajes.Include(x => x.peliculaSeries).ToListAsync();
            //return new List<Personajes>();
            //awai metodo asincronico
            //retorna la lista de la clase personaje e incluye la de peliculasseries
            
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Personaje>> Get(int id)
        {
            // await metodo a ejecutar asincronico
            Personaje dibujo = await context.personajes.Where(x => x.Id == id).FirstOrDefaultAsync();
            //x=>x.id x seria el registro delnde esta el id 
            if (dibujo == null)
            {
                return NotFound($"No existe el Personaje con id igual a {id}.");
            }
            return dibujo;
        }
        [HttpPost]//agrega un elemento 


        //metodo que me agrega un elemento para q salga desp en la lista, es un metodo publico que me va 
        //devolver una action resultado osea <un nombre de personaje> seria el parametro 
        public async Task<ActionResult<Personaje>> PostAsync(Personaje dibujo)//se el nombre del personaje pero 
                                                                                      //no conozco el ID eso me lo da la base 
        {
            /* context.Alumnos.Add(personaje);//digo que agrego pero luego debo guardarlo
             context.SaveChanges();
             return estudiantes;*/
            try
            {
                context.personajes.Add(dibujo);
                await context.SaveChangesAsync();
                return dibujo;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id:int}")] //modificacion de datos
        public async Task<ActionResult> Put(int id, [FromBody] Personaje dibujo)
        {

            //bsco un usuario de la clase estudiante de la tabla personaje x id

            Personaje personajeencontrado = await context.personajes.Where(x => x.Id == id).FirstOrDefaultAsync();
            //si mi id es null no existe 
            if (personajeencontrado == null)
            {
                return NotFound("no existe el estudiante a modificar.");
            }
            //si es correcto puedo modificar todo lo q sigue
            personajeencontrado.Imagen = dibujo.Imagen;
            personajeencontrado.Edad = dibujo.Edad;
            personajeencontrado.Historia = dibujo.Historia;
            personajeencontrado.Nombre = dibujo.Nombre;
            personajeencontrado.Peso = dibujo.Peso;
            personajeencontrado.PeliculasSeriesAsociadas = dibujo.PeliculasSeriesAsociadas;

            try
            {
                context.personajes.Update(personajeencontrado);
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
            Personaje dibujo = await context.personajes.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (dibujo == null)//parametro de q no puede ser nulo el dato
            {
                return NotFound($"No existe el personaje con id igual a {id}.");//retorna error
            }
            //try uso de excepcion ya que en la ejecuc  ion hubo un error en el id del estudiante y se desea que siga
            //ejecutandose por lo q el uso correcto es el try catch
            try
            {
                context.personajes.Remove(dibujo);//borrar estudiante de la table alumno
                await context.SaveChangesAsync();//busca el dato guardado
                return Ok($"El estudiante {dibujo.Nombre} ha sido borrado.");//retorna q se borro
            }
            catch (Exception) //se captura la excepcion del try
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }

        }

    }
}
