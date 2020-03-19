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
        private static List<Record> list = new List<Record>();

        public void Clear()
        {
            list = new List<Record>();
            _nextId = 1;
        }

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
            //foreach (Record r in list)
            //{
            //    if (r.Id == id) return r;
            //}

            //return null;
            return list.Find(i => i.Id == id);
        }

        // POST api/<controller>
        [HttpPost]
        public Record Post([FromBody]Record value)
        {
            Record r = value;
            r.Id = _nextId;
            list.Add(r);
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
