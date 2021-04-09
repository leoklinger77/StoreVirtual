using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreVirtual.Service.File;

namespace StoreVirtual.Areas.Funcionario.Controllers
{
    [Area("Funcionario")]
    public class ImagemController : Controller
    {
        public IActionResult InsertImage(IFormFile file)
        {
            var caminho = FileManagement.InsertImageProduto(file);

            if (caminho.Length > 0)
            {
                return Ok(new { caminho = caminho });
            }

            return new StatusCodeResult(500);
        }

        public IActionResult RemoveImage(string caminho)
        {
            if (FileManagement.RemoveImage(caminho))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
