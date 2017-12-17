using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentio.Areas.Admin.Services
{
    interface IAdminServices
    {
        void AddArticle(string author, string title, string content);

    }
}
