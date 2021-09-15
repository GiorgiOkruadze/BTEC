using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.ApplicationServices.FileStorageServices
{
    public class CloudinaryService
    {
        public string ApiKey { get; set; } = "917751897546634";
        public string ApiSecret { get; set; } = "zJjTgbtW6whsT-feRg5F-LGs-KM";
        public string Cloud { get; set; } = "itacademystep-develoeprs";


        public string UploadFile(string filePath)
        {
            var myAccount = new Account { ApiKey = ApiKey, ApiSecret = ApiSecret, Cloud = Cloud };
            Cloudinary _cloudinary = new Cloudinary(myAccount);
            var uploadParams = new VideoUploadParams()
            {
                File = new FileDescription(filePath)
            };
            var uploadResult = _cloudinary.Upload(uploadParams);
            return uploadResult.Url.AbsoluteUri;
        }
    }
}
