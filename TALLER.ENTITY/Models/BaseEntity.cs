﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace TALLER.ENTITY.Models
{
    public class BaseEntity 
    {

        [Key]
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Status{ get; set; }
       
    }
}
