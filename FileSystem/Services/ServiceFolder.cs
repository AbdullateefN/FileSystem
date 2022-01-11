using AutoMapper;
using FileSystem.Models;
using FileSystem.Models.Dto;
using FileSystem.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileSystem.Services
{
    public class ServiceFolder : IServiceFolder
    {
        public IUnitOfWork unitOfWork { get; }
        public IMapper mapper { get; }

        public ServiceFolder(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<IEnumerable<FolderDto>> ListOfFolders()
        {
            var list = await unitOfWork.folderRepository.ListOfFolders();
            var result = mapper.Map<IEnumerable<FolderDto>>(list);
            return result;
        }
        public async Task<FolderDto> GetId(int id)
        {
            var findId = await unitOfWork.folderRepository.GetId(id);

            var result = mapper.Map<FolderDto>(findId);

            return result;
        }
        public async Task<bool> addFolder(FolderDto folderDto)
        {
            Folder folder = mapper.Map<FolderDto, Folder>(folderDto);
            await unitOfWork.folderRepository.addFolder(folder);

            await unitOfWork.CompleteAsync();
            return true;
        }
        public async Task<bool> EditFolder(FolderDto folderDto, int id)
        {
            var folder = await unitOfWork.folderRepository.GetId(id);

            //folder.FolderName = folderDto.FolderName;

            mapper.Map(folderDto, folder);

             unitOfWork.folderRepository.EditFolder(folder);

            await unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<bool> DeleteFolder(int id)
        {


           
              unitOfWork.folderRepository.RemoveFolder(id);
            ////mapper.Map<FolderDto>(deleteFolder);
            

            await unitOfWork.CompleteAsync();

            return true;
        }
    }
}
