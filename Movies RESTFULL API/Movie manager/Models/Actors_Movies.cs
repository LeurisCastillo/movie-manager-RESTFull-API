﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_manager.Models
{
    public class Actors_Movies
    {
        public int Id { get; set; }


        public int ActorId { get; set; }
        public Actor Actor { get; set; }


        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
