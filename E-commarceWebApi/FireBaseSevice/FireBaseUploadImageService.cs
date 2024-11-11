using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commrece.Domain.FireBaseSevice;
using Firebase.Storage;

namespace E_commarceWebApi.FireBaseSevice
{
    public class FireBaseUploadImageService : IFireBaseUploadImageService
    {
        private readonly FireBaseService _fireBaseService;
        //private readonly IDatabaseService _databaseService;

        private const long FirebaseStorageLimitBytes = 1L * 1024 * 1024 * 1024;
        public FireBaseUploadImageService(FireBaseService fireBaseService)
        {
            _fireBaseService = fireBaseService;

        }

        public async Task<string> FireBaseDeleteImageAsync(string fileName, string folderName)
        {
            var storge = new FirebaseStorage(_fireBaseService._Bucketname);
            await storge.Child(folderName).Child(fileName).DeleteAsync();
            return fileName;
        }

        public async Task<string> FireBaseGetImageAsync(string fileName, string folderName)
        {
            var storge = new FirebaseStorage(_fireBaseService._Bucketname);
            var DowloadUrl = await storge.Child(folderName).Child(fileName).GetDownloadUrlAsync();
            return DowloadUrl;
        }

        public async Task<string> FireBaseUploadImageAsync(string fileName, string filePath, string folderName)
        {
            var storge = new FirebaseStorage(_fireBaseService._Bucketname);
            var DowloadUrl = await storge.Child(folderName).Child(fileName).PutAsync(System.IO.File.OpenRead(filePath));
            return DowloadUrl;
        }
    }
}
