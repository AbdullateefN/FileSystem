using FileSystem.Context;
using System.Threading.Tasks;

namespace FileSystem.Models
{
    public interface IUnitOfWork
    {
        IFolderRepository folderRepository { get; }
        IFileRepository fileRepository { get; }
        Task CompleteAsync ();
    }
}
