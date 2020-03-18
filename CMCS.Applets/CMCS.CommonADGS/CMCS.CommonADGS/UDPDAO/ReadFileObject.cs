using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.CommonADGS.UDPDAO
{
    public class ReadFileObject
    {
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

        public ReadFileObject(int index, byte[] buffer)
        {
            Index = index;
            Buffer = buffer;
        }
    }
}
