﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryCacheDemo.Models
{
    public class DependentViewModel
    {
        public DateTime? ParentCachedTime { get; set; }
        public DateTime? ChildCachedTime { get; set; }
        public string Message { get; set; }
    }
}
