using FileSystem.Context;
using FileSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileSystem.Models
{
    public class FileRepository: IFileRepository
    {

        private readonly AppDBContext db;

        public FileRepository(AppDBContext _db)
        {
            db = _db;
        }
        public async Task<IEnumerable<File>> ListOfFiles()
        {
            return await db.Files.ToListAsync();
        }
        public async Task<File> GetId(int id)
        {
            var findId = await db.Files.FindAsync(id);

            return findId;
        }
       public async Task<bool> addFiles(File file)
        {
            await db.Files.AddAsync(file);

            return true;
        }
       public bool EditFiles(File file)
        {
           
                db.Files.Update(file);
               
            return true;
        }
       public bool DeleteFiles(File file)
        {
            
                db.Files.Remove(file);
                
         
            return true;
        }
    }
}
