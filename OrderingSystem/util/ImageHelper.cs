using System;
using System.Drawing;
using System.IO;
using MySqlConnector;

namespace OrderingSystem.util
{
    public class ImageHelper
    {

        public static Image GetImageFromBlob(MySqlDataReader reader)
        {
            try
            {
                if (!reader.IsDBNull(reader.GetOrdinal("image")))
                {
                    using (MemoryStream ms = new MemoryStream((byte[])reader["image"]))
                    {
                        return Image.FromStream(ms);
                    }
                }
                else
                {
                    return Properties.Resources.placeholder;
                }


            }
            catch (Exception ex)
            {
                return Properties.Resources.placeholder;
            }
        }

        public static byte[] GetImageFromFile(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
