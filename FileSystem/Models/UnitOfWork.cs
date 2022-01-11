using FileSystem.Context;
using System.Threading.Tasks;

namespace FileSystem.Models
{
    public class UnitOfWork:IUnitOfWork
    {
       public IFolderRepository folderRepository { get; } 
       public IFileRepository fileRepository { get; }

       private readonly AppDBContext db;    
        public UnitOfWork(AppDBContext _db,IFolderRepository _folderRepository,IFileRepository _fileRepository)
        {
            folderRepository= _folderRepository;
            fileRepository = _fileRepository;
            db= _db;
        }
      
        public async Task CompleteAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
