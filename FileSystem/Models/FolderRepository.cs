using AutoMapper;
using FileSystem.Context;
using FileSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileSystem.Models
{
    public class FolderRepository: IFolderRepository
    {
        private readonly AppDBContext db;
        
        public FolderRepository(AppDBContext _db)
        {
            db = _db;
        }
       public async Task<IEnumerable<Folder>> ListOfFolders()
        {

            return await db.Folders.ToListAsync();
        }
        public async Task<Folder> GetId(int id)
        {
            var findId = await db.Folders.FindAsync(id);
            return findId;
        }
        public async Task<bool> addFolder(Folder folder)
        {
           
            await db.Folders.AddAsync(folder);

            return true;    
        }
        public bool EditFolder(Folder folder)
        {
            db.Folders.Update(folder);

            return true;
        }

        public void RemoveFolder(int id)
        {
            RemoveCascade(id);
        }
        public void RemoveCascade(int id)
        {
            IEnumerable<Folder> results = db.Folders.Where(f => f.FolderParentId == id);
            List<int?> ContainerIds = results.Select(l => l.FolderParentId).ToList();
            foreach (Folder folder in results)
            {
                if (!ContainerIds.Contains(folder.FolderId))
                    db.Folders.Remove(folder);
                else
                    RemoveCascade(folder.FolderId);
            }
            Folder result = db.Folders.Single(f => f.FolderId == id);
            db.Folders.Remove(result);
        }
    }
}
