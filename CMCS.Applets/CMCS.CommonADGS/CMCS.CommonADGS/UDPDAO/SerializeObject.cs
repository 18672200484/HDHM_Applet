using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace CMCS.CommonADGS.UDPDAO
{
    public class SerializeObject
    {
        public static byte[] Serialize(object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            bf.Serialize(stream, obj);
            byte[] datas = stream.ToArray();
            stream.Dispose();
            return datas;
        }

        public static object Deserialize(byte[] datas)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream stream = new MemoryStream(datas, 0, datas.Length);
            object obj = bf.Deserialize(stream);
            stream.Dispose();
            return obj;
        }
    }
}
