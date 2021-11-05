using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PersonCompany> CompanyPeople { get; set; } = new HashSet<PersonCompany>();
    }
}
