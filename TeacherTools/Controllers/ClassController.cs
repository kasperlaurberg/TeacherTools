using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using TeacherTools.Database.Context;
using TeacherTools.DB.Repository.Interfaces;
using TeacherTools.Model;

namespace TeacherTools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        public IClassRepository ClassRepository { get; set; }

        public ClassController(IClassRepository repo)
        {
            ClassRepository = repo;
        }
        
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassDocument>>> Get()
        {
            var result = await ClassRepository.ListAsync();
            return new JsonResult(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                return StatusCode(500);
            }

            var result = await ClassRepository.SingleOrDefaultAsync( c => c.Id == objectId);
            return new JsonResult(result);
        }

        // POST api/values
        [HttpPost]
        public async void Post([FromBody] ClassDocument classDoc)
        {
            await ClassRepository.AddAsync(classDoc);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async void Put([FromBody] ClassDocument classDoc)
        {
            await ClassRepository.UpdateAsync(classDoc, classDoc.Id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            if (ObjectId.TryParse(id, out var objectId))
            {
                await ClassRepository.DeleteAsync(objectId);
            }
        }

        // POST api/values
        [HttpGet("generatetestdata")]
        public bool GenerateTestData()
        {
            ClassRepository.Add(new ClassDocument() { Name = "A", Year = 1, Description = "1.A" });
            ClassRepository.Add(new ClassDocument() { Name = "B", Year = 2, Description = "2.B" });

            return true;
        }
    }
}
