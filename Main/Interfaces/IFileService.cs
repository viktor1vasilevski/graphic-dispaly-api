using Main.DTO;
using Main.DTO.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Interfaces
{
    public interface IFileService
    {
        ApiResponse<List<ItemInfoDTO>> GetAllItemsInfo();
        ServerResponse ReadTxtFile(IFormFile file);
    }
}
