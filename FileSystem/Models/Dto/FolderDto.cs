using FileSystem.Models.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FileSystem.Models.Dto
{
    public class FolderDto
    {
        [Key]
        public int FolderId { get; set; }
        public string FolderName { get; set; }
        public int? FolderParentId { get; set; }
     
    }
}
