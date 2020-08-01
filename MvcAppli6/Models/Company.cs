using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAppli6.Models
{
    public class Company
    {
        public Emp CompanyDirector
        {
            get { hdfcDataModel db = new hdfcDataModel();
            return db.Emps.Single(x=>x.Id==1);
            }
        }
    }
}