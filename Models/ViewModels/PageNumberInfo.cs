﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingSite.Models.ViewModels
{
    public class PageNumberInfo
    {
        public int NumItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumItems { get; set; }

        //Calculate number of pages
        public int NumPages => (int) Math.Ceiling((decimal) TotalNumItems / NumItemsPerPage);
    }
}
