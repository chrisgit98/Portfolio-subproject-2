﻿using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfEx;
using EfEx.Domain;
using Microsoft.EntityFrameworkCore;

namespace EfEx.Domain
{
    
    public class BookmarkTitle
    {
        public char UserId { get; set; }
        public char FilmId { get; set; }

    }

}