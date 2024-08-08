﻿using MVC_FinalProje.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FinalProje.Domain.Entities
{
    public class Admin:AuditableEntity
    {
        public string FirstName {  get; set; }  
        public string LastName { get; set; }    
        public string Email {get; set; }
        public string IdentityId {get; set; }
    }
}
