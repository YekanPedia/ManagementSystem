namespace YekanPedia.ManagementSystem.ExternalService.Interfaces
{
    using System.Collections.Generic;
    using FilesProxy;
    public interface IFilesProxyAdapter
    {
        List<FileInfo> GetFilesAddress(string address);
        string CreateDirectory(string address);
        long DirectorySize();
        string UploadImage(PostedImageFile file);
        FileInfo UploadDocument(PostedFile file);

        void Delete(string address);
    }
}
