using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.BL.Services
{
    public static class imageUploader
    {

        public static string uploader(string foldername, IFormFile myfile)
        {
            try
            {
                string path = Directory.GetCurrentDirectory() + "/wwwroot/files/" + foldername;
                string filename = Guid.NewGuid() + Path.GetFileName(myfile.FileName);
         
                string finalpath = Path.Combine(path, filename);
                using (var stream = new FileStream(finalpath, FileMode.Create))
                {
                    myfile.CopyTo(stream);
                }

                return filename;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public static void delete(string foldername, string filename)
        {
            try
            {
                var path = Directory.GetCurrentDirectory() + "/wwwroot/assets/images/" + foldername + filename;
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

            }
            catch (Exception e)
            {

            }
        }

    }
    }
