using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class UpsertCustomer
    {
        public Customer customer { get; set; }
        public List<State> States { get; set; }
    }
}