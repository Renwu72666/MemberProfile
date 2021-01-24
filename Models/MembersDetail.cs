using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MemberProfile.Models
{
    public class Members
    {
        [Key]
        public int MemberDetailId { get; set; }

        [Column (TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Birthday { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Gender { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Role { get; set; }
    }
}
