using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CONDUIT.UnityCL.Helpers
{
    public class ObjectConverter
    {
        public static T BytesToObject<T>(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            ms.Write(bytes, 0, bytes.Length);
            ms.Seek(0, SeekOrigin.Begin);

            var obj = bf.Deserialize(ms);
            var retObj = (T)obj;

            return retObj;
        }

        public static byte[] ObjectToBytes(object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}
