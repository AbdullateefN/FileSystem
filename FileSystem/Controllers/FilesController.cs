using FileSystem.Context;
using FileSystem.Models;
using FileSystem.Models.Dto;
using FileSystem.Models.Entities;
using FileSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IServiceFile serviceFile;
        public FilesController(IServiceFile _serviceFile)
        {
            serviceFile = _serviceFile;    
                
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<File>>> GetAllFiles()
        {
            return Ok(await serviceFile.ListOfFiles());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<File>> GetFileById(int id)
        {
            
            return Ok(await serviceFile.GetId(id));

        }
        [HttpPost]
        public async Task<ActionResult> CreateFile(FileDto file)
        {
            await serviceFile.addFiles(file);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFile(FileDto file, int id)
        {
            try
            {
              await serviceFile.EditFiles(file,id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFile(int id, FileDto file)
        {
            await serviceFile.DeleteFiles(file,id);
            return Ok();
        }
    }
}
