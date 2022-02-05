using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngineOrderDemo.Logic.Objects
{
    public class PatchData
    {
        public object Value { set; get; }
        public string Path { set; get; }
        public string Op { set; get; }
    }
}
