using AutoMapper;
using FileSystem.Models;
using FileSystem.Models.Dto;
using FileSystem.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileSystem.Services
{
    public interface IServiceFile
    {
        IUnitOfWork unitOfWork { get; }
         IMapper mapper { get; }
        Task<IEnumerable<FileDto>> ListOfFiles();
        Task<FileDto> GetId(int id);
        Task<bool> addFiles(FileDto fileDto);
        Task<bool> EditFiles(FileDto file, int id);
        Task<bool> DeleteFiles(FileDto file, int id);
    }
}
