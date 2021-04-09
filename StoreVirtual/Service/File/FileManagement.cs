using Microsoft.AspNetCore.Http;
using System.IO;

namespace StoreVirtual.Service.File
{
    public class FileManagement
    {
        public static string InsertImageProduto(IFormFile file)
        {
            var NomeArquivo = Path.GetFileName(file.FileName);
            var caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/Temp", NomeArquivo);


            using(var stream = new FileStream(caminho, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return Path.Combine("/uploads/Temp", NomeArquivo);
        }

        public static bool RemoveImage(string caminho)
        {
            string caminhoArmez = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/Temp", caminho.TrimStart('/'));

            if (System.IO.File.Exists(caminhoArmez))
            {
                System.IO.File.Delete(caminhoArmez);
                return true;
            }
            else
            {
                return false;
            }

            
        }
    }
}
