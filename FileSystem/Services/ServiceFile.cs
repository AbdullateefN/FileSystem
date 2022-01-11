using AutoMapper;
using FileSystem.Context;
using FileSystem.Models;
using FileSystem.Models.Dto;
using FileSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileSystem.Services
{
    public class ServiceFile:IServiceFile
    {
        public IUnitOfWork unitOfWork { get; }
        public IMapper mapper { get; }
        public ServiceFile(IUnitOfWork _unitOfWork,IMapper _mapper)
        {

            unitOfWork = _unitOfWork;
            
            mapper = _mapper;    
        }
        public async Task<IEnumerable<FileDto>> ListOfFiles()
        {
           var getAll= await unitOfWork.fileRepository.ListOfFiles();
            var result = mapper.Map<IEnumerable<FileDto>>(getAll);
            return result;
        }
        public async Task<FileDto> GetId(int id)
        {
            var findId = await unitOfWork.fileRepository.GetId(id);
            var result = mapper.Map<FileDto>(findId);

            return result;
        }
        public async Task<bool> addFiles(FileDto fileDto)
        {

            File file = mapper.Map<FileDto, File>(fileDto);
            await unitOfWork.fileRepository.addFiles(file);
            await unitOfWork.CompleteAsync();

            return true;
        }
        public async Task<bool> EditFiles(FileDto fileDto, int id)
        {
            var file = await unitOfWork.fileRepository.GetId(id);

            

            mapper.Map(fileDto, file);

            unitOfWork.fileRepository.EditFiles(file);
           await unitOfWork.CompleteAsync();


            return true;
        }
        public async Task<bool> DeleteFiles(FileDto fileDto, int id)
        {
               var file =await unitOfWork.fileRepository.GetId(id); 
               var deleteFile=  unitOfWork.fileRepository.DeleteFiles(file);
               mapper.Map(fileDto,file);
               await unitOfWork.CompleteAsync();

            return true;
        }
    }
}
