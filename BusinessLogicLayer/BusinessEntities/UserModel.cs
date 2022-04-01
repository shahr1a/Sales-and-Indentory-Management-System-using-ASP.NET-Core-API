using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BusinessEntities
{
    public class UserModel
    {
        public int? UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string? Password { get; set; } = null!;
        public string? UserType { get; set; } = null!;
        public bool IsAdmin { get; set; }
    }
}
