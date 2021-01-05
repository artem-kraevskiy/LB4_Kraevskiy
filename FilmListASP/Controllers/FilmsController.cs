using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentList.Models;

namespace FilmList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmsController : ControllerBase
    {
        public static List<Film> films = new List<Film>();
        private readonly ILogger<FilmsController> _logger;

        public FilmsController(ILogger<FilmsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Film> Get()
        {
            return films;
        }

        [HttpGet("last-id")]
        public int GetLastId()
        {
            return films.Count > 0 ? films[^1].id + 1 : 0;
        }

        [HttpPut]
        [Consumes("application/json")]
        public IActionResult Add(Film f)
        {
            films.Add(s);
            return Created("/film", f);
        }

        [HttpPost]
        public IActionResult Edit(Film f)
        {
            Film temp = films.Find(film => film.id == f.id);
            temp.nazv = f.nazv;
            temp.reit = f.reit;
            temp.zanr = f.zanr;
            temp.opis = f.opis;
            return Accepted();
        }

        [HttpDelete]
        public IActionResult Delete(IEnumerable<int> m)
        {
            List<Film> temp = films.FindAll(f => m.Any(i => i == f.id));
            foreach(var t in temp)
                films.Remove(t);
            return Accepted();
        }
    }
}