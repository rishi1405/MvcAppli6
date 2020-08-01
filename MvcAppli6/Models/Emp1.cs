using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace MvcAppli6.Models
{
    [MetadataType(typeof(EmpMetaData))]    
    public partial class Emp
    {

    }

    public class EmpMetaData
    {
        // Id property is hidden and cannot be changed
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        // EmailAddress is read only
        [ReadOnly(true)]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Currency)]
        public int? Salary { get; set; }

        [DataType(DataType.Url)]
        [UIHint("OpenInNewWindow")]
        public string PersonalWebSite { get; set; }

        [DisplayAttribute(Name = "Full Name")]
        public string FullName { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? HireDate { get; set; }

        [DisplayFormat(NullDisplayText = "Gender not specified")]
        public string Gender { get; set; }
    }

}