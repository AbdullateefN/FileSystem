using FileSystem.Context;
using FileSystem.Models;
using FileSystem.Models.Dto;
using FileSystem.Models.Entities;
using FileSystem.Services;
using Hl7.Fhir.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly IServiceFolder serviceFolder;
        public FolderController(IServiceFolder _serviceFolder)
        {
            serviceFolder = _serviceFolder;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FolderDto>>> GetAllFolders() =>
            Ok(await serviceFolder.ListOfFolders());

        [HttpGet("{id}")]
        public async Task<ActionResult<FolderDto>> GetByIdFolder(int id)
        {
         
          return Ok(await serviceFolder.GetId(id));    
          
        }
        [HttpPost]
        public async Task<ActionResult> CreateFolder(FolderDto folder)
        {
            try
            {

             await serviceFolder.addFolder(folder);
            }
            catch (System.Exception ex)
            {

                throw;
            }
            return Ok();  
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFolder(FolderDto folder,int id)
        {
            try
            {
                await serviceFolder.EditFolder(folder,id); 
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);  
            }
           
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFolder(int id)
        {
            try
            {

           await serviceFolder.DeleteFolder(id);

            }
            catch (System.Exception ex)
            {

                throw;
            }
            return Ok();
        }
    }
}
