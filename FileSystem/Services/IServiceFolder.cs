using AutoMapper;
using FileSystem.Models;
using FileSystem.Models.Dto;
using FileSystem.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileSystem.Services
{
    public interface IServiceFolder
    {
        IUnitOfWork unitOfWork { get; }
        IMapper mapper { get; }
        Task<IEnumerable<FolderDto>> ListOfFolders();
        Task<FolderDto> GetId(int id);
        Task<bool> addFolder(FolderDto folderDto);
        Task <bool> EditFolder(FolderDto folderDto, int id);
        Task<bool> DeleteFolder( int id);
    }
}
