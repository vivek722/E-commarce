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
        public Boolean IsPageActive { get; set; }
        public Boolean IsLoderActive { get; set; }
        public Boolean IsTosterActive { get; set; }
        public Boolean IsDeleteDialogActive { get; set; }
    }
}
