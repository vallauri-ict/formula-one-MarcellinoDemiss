﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace toDoApi.Models
{
    public class toDoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string Secret { get; set; }
    }
}
