namespace DoktorKlinik.Web.Components
{
    public class ProfilUpdate
    {
        public static string Photo(IFormFile file,string folder)
        {
            if (Directory.Exists($"wwwroot/{folder}"))
            {
                Directory.CreateDirectory($"wwwroot/{folder}");
            }
            var path = $"Fotograf/{folder}" + Guid.NewGuid().ToString("N") + file.FileName;
            var stream = System.IO.File.OpenWrite("wwwroot/" + path);
            file.CopyTo(stream);

            return "/" + path;
        }
    }
}
