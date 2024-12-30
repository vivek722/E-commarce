
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
    public class SupplierPageSetting : BaseEntityModel
    {
        public string PageName { get; set; }
        public string IsPageActive { get; set; }
        public string IsLoderActive { get; set; }
        public string IsTosterActive { get; set; }
        public string IsDeleteDialogActive { get; set; }
    }
}
