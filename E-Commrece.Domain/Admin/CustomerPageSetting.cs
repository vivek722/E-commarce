using E_Commrece.Domain.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.Admin
{
    public class CustomerPageSetting : BaseEntityModel
    {
        public string PageName { get; set; }
        public string IsPageActive { get; set; }
        public string IsLoderActive { get; set; }
        public string IsTosterActive { get; set; }
        public string IsDeleteDialogActive { get; set; }
    }
}
