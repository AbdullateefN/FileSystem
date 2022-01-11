using FileSystem.Context;
using FileSystem.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileSystem.Models
{
    public interface IFolderRepository
    {
         Task<IEnumerable<Folder>> ListOfFolders();
         Task<Folder> GetId(int id);
         Task<bool> addFolder(Folder folder);
         bool EditFolder(Folder folder);
         

        void RemoveFolder(int id);


    }
}
