using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginMangement.Model
{
    public class ApplicationRole
    {
        public const string User = "User";
        public const string Admin = "Admin";

        public string Name { get; internal set; }
        public DateTime CreatedDate { get; internal set; }
        public string Description { get; internal set; }
        public string IPAddress { get; internal set; }
        public string Id { get; internal set; }
        public string RoleName { get; internal set; }
        public object Users { get; internal set; }
    }
}
