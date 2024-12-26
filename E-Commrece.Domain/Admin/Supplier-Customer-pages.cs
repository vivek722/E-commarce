
using E_commerce.Ef.Core.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commrece.Domain.BaseClass;

namespace E_Commrece.Domain.Admin
{
    public class Supplier_Customer_pages : BaseEntityModel
    {
        public string PageName { get; set; }
        public Boolean IsPageActive { get; set; }
        public Boolean IsLoderActive { get; set; }
        public Boolean IsTosterActive { get; set; }
        public Boolean IsDeleteDialogActive { get; set; }
    }
}
