﻿using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidzy
{
    public class MovieDirector
    {
        public int MovieId { get; set; }

        public Movie? Movie { get; set; }

        public int DirectorId { get; set; }

        public Director? Director { get; set; }
    }
}
