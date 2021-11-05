using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link
{
    public class PersonCompany
    {
        public int PersonId { get; set; }
        public int CompanyId { get; set; }

        public Person Person { get; set; }
        public Company Company { get; set; }
    }
}
