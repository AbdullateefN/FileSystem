using FileSystem.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileSystem.Models
{
    public interface IFileRepository
    {
        Task<IEnumerable<File>> ListOfFiles();
        Task<File> GetId(int id);
        Task<bool> addFiles(File file);
        bool EditFiles(File file);
        bool DeleteFiles(File file);
    }
}
