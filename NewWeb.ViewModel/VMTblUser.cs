using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewWeb.ViewModel
{
    public class VMTblUser
    {
        public int Id { get; set; }
        public string? nama_lengkap { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? status { get; set; }
    }
}
