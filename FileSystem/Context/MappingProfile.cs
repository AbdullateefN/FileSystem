using AutoMapper;
using FileSystem.Models.Dto;
using FileSystem.Models.Entities;

namespace FileSystem.Context
{

    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Folder, FolderDto>().ReverseMap();
            CreateMap<File, FileDto>().ReverseMap();
        }
        
    }
}
