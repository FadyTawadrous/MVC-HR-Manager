
namespace Tiers.BLL.Helper
{
    public static class Upload
    {
        public static async Task<string> UploadFileAsync(string FolderName, IFormFile File)
        {
            try
            {
                if (File == null || File.Length == 0)
                    throw new ArgumentException("File is empty");

                //catch the folder Path and the file name in server
                // 1 ) Get Directory
                string FolderPath = Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName;


                //2) Get File Name
                string FileName = Guid.NewGuid() + Path.GetFileName(File.FileName);
                //Guid => Word contain from 36 character

                // 3) Merge Path with File Name
                string FinalPath = Path.Combine(FolderPath, FileName);
                //combine put /

                //4) Save File As Streams "Data Overtime"
                using (var Stream = new FileStream(FinalPath, FileMode.Create))
                {
                    await File.CopyToAsync(Stream);
                }

                return FileName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        public static async Task<bool> RemoveFileAsync(string FolderName, string fileName)
        {
            try
            {
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", FolderName, fileName);

                if (File.Exists(directory))
                {
                    await Task.Run(() => File.Delete(directory));
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
