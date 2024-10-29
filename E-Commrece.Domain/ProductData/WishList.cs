using E_commerce.Ef.Core.Product;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.ProductData
{
    public class Wishlist : BaseEntityModel
    {  
        public int UserId { get; set; }         
        public int ProductId { get; set; }        
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
        public Users User { get; set; }
        public Products Product { get; set; }
    }

}
