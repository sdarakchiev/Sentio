using Sentio.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Sentio.Data.ViewModels
{
    public class ProfileViewModel
    {
        public string Username { get; set; }

        public ICollection<Article> FavoriteArticles { get; set; }
    }
}
