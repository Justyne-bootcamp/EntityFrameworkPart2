﻿using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameworkPart2.Models
{
    public partial class Payment
    {
        public string CSourceCode { get; set; }
        public decimal? MAmount { get; set; }
        public string CChequeNo { get; set; }
        public DateTime DDate { get; set; }
    }
}
