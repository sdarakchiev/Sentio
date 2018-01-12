using Bytes2you.Validation;
using Sentio.Data.ViewModels;
using Sentio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sentio.Services
{
    public class ProfileServices : IProfileServices
    {
        private readonly ApplicationDbContext dbContext;

        public ProfileServices(ApplicationDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();

            this.dbContext = dbContext;
        }

       
    }
}