using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.FireBaseSevice
{
    public interface IFireBaseUploadImageService
    {
        Task<string> FireBaseUploadImageAsync(string fileName, string filePath, string folderName);
        Task<string> FireBaseDeleteImageAsync(string fileName,string folderName);
        Task<string> FireBaseGetImageAsync(string fileName, string folderName);


    }
}
