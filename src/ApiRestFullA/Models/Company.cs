using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestFullA.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string IdentificationType  { get; set; }
        public string Identificationnumber { get; set; }
        public string Companyname { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Firstlastname { get; set; }
        public string Secondlastname { get; set; }
        public string email { get; set; }

    }
}
