﻿using BlogAppNetCore.Entities.Concrete;
using BlogAppNetCore.Shared.Entities.Abstract;
using BlogAppNetCore.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppNetCore.Entities.Dtos
{
    public class ArticleDto : DtoGetBase
    {
        public Article Article { get; set; }
    }
}
