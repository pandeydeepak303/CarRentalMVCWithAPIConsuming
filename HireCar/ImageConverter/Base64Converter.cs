using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HireCar.ImageConverter
{
    public class Base64Converter
    {

        public string ImgToBase64(HttpPostedFileBase image)
        {
            System.IO.Stream fs = image.InputStream;
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            string base64String = "data:image/jpeg;base64," + Convert.ToBase64String(bytes, 0, bytes.Length);
            return base64String;
        }

    }
}