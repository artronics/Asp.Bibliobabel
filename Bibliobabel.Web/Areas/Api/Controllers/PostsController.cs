using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bibliobabel.Data;
using Bibliobabel.Data.Repositories;
using Bibliobabel.Domain.Models;
using Bibliobabel.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bibliobabel.Web.Areas.Api.Controllers
{
    public class PostsController : ApiController
    {
        private readonly IRepository<Post> _postRepository;

        public PostsController(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public Post Get(int id)
        {
            return _postRepository.GetById(id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}