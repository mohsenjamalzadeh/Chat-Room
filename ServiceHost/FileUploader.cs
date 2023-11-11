using _01_framework.Application;

namespace ServiceHost
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _environment;

        public FileUploader(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public string Upload(IFormFile file, string path)
        {
            if (file is null || file.Length == 0)
                return "";

            var directoryPath = Path.Combine(_environment.WebRootPath, "UploaderFile", path);
            Directory.CreateDirectory(directoryPath);

            string fileName = $"{DateTime.Now.ToFileTime()}--{file.FileName}";
            string filePath = Path.Combine(directoryPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return $"{path}/{fileName}";
        }
    }
}
