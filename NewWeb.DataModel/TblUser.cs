using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NewWeb.DataModel
{
    [Table("tbl_user")]
    public partial class TblUser
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("nama_lengkap")]
        [StringLength(20)]
        [Unicode(false)]
        public string NamaLengkap { get; set; } = null!;
        [Column("username")]
        [StringLength(20)]
        [Unicode(false)]
        public string Username { get; set; } = null!;
        [Column("password")]
        [StringLength(10)]
        [Unicode(false)]
        public string Password { get; set; } = null!;
        [Column("status")]
        [StringLength(1)]
        [Unicode(false)]
        public string Status { get; set; } = null!;
    }
}
