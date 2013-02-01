using System;
using System.Collections.Generic;

namespace Epic.Data
{
    public interface IGlobalData
    {
        void Initialize(GlobalObject obj);
        object GetData();
    }

    public class GlobalObject
    {
        
    }
}