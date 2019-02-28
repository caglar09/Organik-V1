using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using Microsoft.AspNetCore.Http.Internal;
using System.Net.Http.Headers;

namespace OrganikV1.Common
{
   public static class IOExtension
    {
        
        public static string Upload(this IFormFile fl, string folder,  string ext = ".png,.jpg,.jpeg",
           int maxSize = 4096000)
        {
            
            if (fl.Length == 0)
                throw new Exception("Görsel Seçilmedi");

            if (!ext.Contains(Path.GetExtension(fl.FileName).ToLower()))
                throw new Exception(string.Format("Görsel uzantısı {0} olmalıdır", ext));

            if (fl.Length > (maxSize))
                throw new Exception(string.Format("Görsel {0}KB dan büyük olamaz", maxSize.ToString().Substring(0, 3)));

            var flName = string.Format("{0}-{1}{2}", fl.FileName.ToCleanUrl(), Utility.GetRandomStr(10), Path.GetExtension(fl.FileName));
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UserFiles",folder, flName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                fl.CopyTo(stream);
                
            }

            //fl.CopyTo(string.Format("~/UserFiles/{0}/{1}", folder, flName));
            return flName;

            
            
        }
    }
}
