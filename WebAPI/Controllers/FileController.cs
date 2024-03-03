using Main.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }



        [HttpGet("GetAllItemsInfoData")]
        public IActionResult GetAllItemsInfo()
        {
            var response = _fileService.GetAllItemsInfo();
            return Ok(response);
        }

        [HttpPost("Upload")]
        public IActionResult UploadFile()
        {
            var response = _fileService.ReadTxtFile(Request.Form.Files[0]);
            return Ok(response);
        }
    }
}
