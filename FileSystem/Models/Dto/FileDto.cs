using System.ComponentModel.DataAnnotations;

namespace FileSystem.Models.Dto
{
    public class FileDto
    {
        public int FileId { get; set; }
        public string FileName { get; set; }

        public int? FolderId { get; set; }
    }
}
