using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using LMSData.Model;

namespace LMSData.Model
{
    public class AttachmentList: MappingBase
    {
        //[Key]
        //public int Id { get; set; }
        
        public Attachment Attachment { get; set; }        
    }
}
