using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo.Models
{
    public class PrivilegedMemberBuilder : MemberBuilder<PrivilegedMemberBuilder>
    {
        public PrivilegedMemberBuilder SetRole(string roleName)
        {
            Console.WriteLine($"Role: {roleName}");
            return this;
        }

    }
}
