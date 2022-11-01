using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Models
{
    public class Price
    {
        [Key]
        public int Id { get; set; }

        public int Money  { get; set; }

        public List<DonatePrice> DonatePrices { get; set; }
    }
}
