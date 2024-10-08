namespace StayCation.API.VerticalSlicing.Common.Helpers
{
    public static class FileHelper
    {
        public static string FileName;

        public static string UploadImg(IFormFile file, string folderName)
        {
            string folderPathe = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);

            string fileName = $"{Guid.NewGuid()}{Path.GetFileName(file.FileName)}";

            string filePath = Path.Combine(folderPathe, fileName);

            FileName = fileName;

            using FileStream FS = new FileStream(filePath, FileMode.Create);

            file.CopyTo(FS);

            return folderPathe;
        }
    }
}
