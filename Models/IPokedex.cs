﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex3.Models
{
    public interface IPokedex
    {
        Pokemon Get(int id);
        List<Pokemon> GetAll();
        public DateTime GeneratedAt { get; set; }
    }
}
