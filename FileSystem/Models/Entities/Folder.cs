using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FileSystem.Models.Entities
{
    public class Folder
    {
        public int FolderId { get; set; }
        public string FolderName { get; set; }

        public int? FolderParentId { get; set; }
        public Folder? FolderParent { get; set; }

        public ICollection<File> Files { get; set; }

        public Folder()
        {

        }
    }
}
