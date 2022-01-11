namespace FileSystem.Models.Entities
{
    public class File
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public int? FolderId { get; set; }
        public Folder Folder { get; set; }
    }
}
