using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.FireBaseSevice
{
    public class FireBaseService
    {
        public string _Bucketname { get; set; }

        public string _FireBaseStorageUrl { get; set; }

        public FireBaseService(string Bucketname, string FireBaseStorageUrl)
        {
            _Bucketname = Bucketname;
            _FireBaseStorageUrl = FireBaseStorageUrl;
        }   
    }
}
