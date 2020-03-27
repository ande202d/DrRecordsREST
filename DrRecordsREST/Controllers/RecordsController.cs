using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DrRecordsREST.Controllers
{
    [Route("api/[controller]")]
    public class RecordsController : Controller
    {
        private static List<Record> list = new List<Record>()
        //to troubleshoot use {localhost}/swagger/v1/swagger.json
        {
            new Record("AndersUndervisning1", "Anders1", 69, 2000),
            new Record("AndersUndervisning2", "Anders2", 69, 1990),
            new Record("AndersUndervisning3", "Anders3", 69, 1980),
            new Record("AndersUndervisning4", "Anders4", 69, 1970),
            new Record("AndersUndervisning5", "Anders5", 69, 1960),
            new Record("AndersUndervisning6", "Anders6", 69, 1960)
        };

        //public void Clear()
        //{
        //    list = new List<Record>();
        //    _nextId = 1;
        //}

        private static int _nextId = 1;
        // GET: api/<controller>
        [HttpGet]
        public List<Record> Get()
        {
            return list;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Record Get(int id)
        {
            return list.Find(i => i.Id == id);
        }

        // GET api/<controller>/year/1950
        //give me everything publiced after 1950
        //[HttpGet]
        //[Route("year/{year}")]
        //public List<Record> GetByYear(int year)
        //{
        //    return list.FindAll(i => i.YearOfPublication >= year);
        //}

        //YEAR
        [HttpGet]
        [Route("search/year/{s}")]
        public List<Record> GetByYear(int s)
        {
            return list.FindAll(i => i.YearOfPublication >= s);
        }
        //TITLE
        [HttpGet]
        [Route("search/title/{s}")]
        public List<Record> GetByTitle(string s)
        {
            return list.FindAll(i => i.Title.ToLower().Contains(s.ToLower()));
        }
        //ARTIST
        [HttpGet]
        [Route("search/artist/{s}")]
        public List<Record> GetByArtist(string s)
        {
            return list.FindAll(i => i.Artist.ToLower().Contains(s.ToLower()));
        }


        // POST api/<controller>
        [HttpPost]
        public Record Post([FromBody]Record value)
        {
            Record r = value;
            r.Id = _nextId;
            list.Add(value);
            _nextId++;
            return r;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Record value)
        {
            Record r = Get(id);
            if (r != null)
            {
                r.Title = value.Title;
                r.Artist = value.Artist;
                r.DurationInSeconds = value.DurationInSeconds;
                r.YearOfPublication = value.YearOfPublication;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            list.Remove(Get(id));
        }
    }
}
