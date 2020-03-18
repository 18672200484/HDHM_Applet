using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.CommonADGS.UDPDAO
{
    /// <summary>
    /// 数据包
    /// </summary>
    [Serializable]
    public class TraFransfersFile
    {
        public TraFransfersFile(int index, byte[] buffer)
        {
            Index = index;
            Buffer = buffer;
        }

        public int Index
        {
            get;
            set;
        }

        public byte[] Buffer
        {
            get;
            set;
        }
    }
}
