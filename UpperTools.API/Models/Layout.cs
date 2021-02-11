using System;
using System.Collections;
using System.Collections.Generic;

namespace UpperTools.API.Models
{
    public class Layout
    {
        public string Supplier{get;set;}
        public FileType UsedFileType{get;set;}

        public List<Fields> Fields {get;set;}

        
    }
}
