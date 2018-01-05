﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentio.Data.ViewModels
{
    public class ArticleCommentViewModel
    {
        public string UserId { get; set; }

        public int ArticleId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
