using AutoMapper;
using EntityModels.Interfaces;
using EntityModels.Models;
using Main.Constants;
using Main.DTO;
using Main.DTO.Responses;
using Main.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;
        private int _successfulProccesses;
        public FileService(IFileRepository fileRepository, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
            _successfulProccesses = 0;
        }

        public ApiResponse<List<ItemInfoDTO>> GetAllItemsInfo()
        {
            var response = new ApiResponse<List<ItemInfoDTO>>();

            try
            {
                var itemInfoData = _fileRepository.GetAll();

                response.Success = true;
                response.Data = _mapper.Map<List<ItemInfoDTO>>(itemInfoData);
                response.Data = response.Data.OrderBy(x => x.Created).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public ServerResponse ReadTxtFile(IFormFile file)
        {
            var response = new ServerResponse();
            try
            {
                if (file.Length > 0)
                {
                    if (file.ContentType.ToLower() == "text/plain" || Path.GetExtension(file.FileName).ToLower() == ".txt")
                    {
                        using (var streamReader = new StreamReader(file.OpenReadStream()))
                        {
                            var fileContent = streamReader.ReadToEnd();
                            var status = ManipulateFileContent(fileContent);

                            response.Success = true;
                            response.Message = status.Message;
                        }
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = FileConstants.FILE_IS_NOT_TXT_FORMAT;
                    }

                }
                else
                {
                    response.Success = false;
                    response.Message = FileConstants.FILE_LENGTH_IS_MORE_THEN_1;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        private ServerResponse ManipulateFileContent(string fileContent)
        {
            var response = new ServerResponse();

            var fileContentSplitedList = fileContent.Split("-");
            var trimedContent = CleanseAndTrimFileContent(fileContentSplitedList);
            _successfulProccesses = 0;

            foreach (var blockItem in trimedContent)
            {
                ProcessBlockItem(blockItem);
            }

            response.Message = $"Procesed {_successfulProccesses} rows from {trimedContent.Count} records.";
            response.Success = true;

            return response;
        }

        private List<string> CleanseAndTrimFileContent(string[] contentArray)
        {
            var contentList = new List<string>(contentArray);
            contentList.RemoveAll(String.IsNullOrWhiteSpace);
            contentList.ForEach(item => item.Trim());
            return contentList;
        }

        private void ProcessBlockItem(string blockItem)
        {
            var trimedCellItem = GetTrimmedCellItems(blockItem);

            if (!String.IsNullOrEmpty(trimedCellItem[0]) && !String.IsNullOrEmpty(trimedCellItem[2]) && trimedCellItem.Count == 3)
            {
                var dto = CreateItemInfoDTO(trimedCellItem);

                if (dto.Success)
                {
                    var itemInfo = _mapper.Map<ItemInfo>(dto.Data);

                    _fileRepository.Add(itemInfo);
                    _fileRepository.SaveChanges();
                    _successfulProccesses++;
                }
            }
        }

        private List<string> GetTrimmedCellItems(string blockItem)
        {
            var cellItem = blockItem.Split(",");
            var cell = new List<string>(cellItem);

            var trimedCellItem = new List<string>();
            cell.ForEach(item => trimedCellItem.Add(item.Trim()));

            return trimedCellItem;
        }

        private ApiResponse<ItemInfoDTO> CreateItemInfoDTO(List<string> trimedCellItem)
        {

            var response = new ApiResponse<ItemInfoDTO>();

            var dto = new ItemInfoDTO
            {
                Color = trimedCellItem[0],
                Label = trimedCellItem[2],
                Created = DateTime.Now
            };

            if (int.TryParse(trimedCellItem[1], out int parsedNumber))
            {
                dto.Number = parsedNumber;
                response.Success = true;
                response.Data = dto;
            }
            else
            {
                response.Success = false;
            }
            
            return response;       
        }
    }
}
