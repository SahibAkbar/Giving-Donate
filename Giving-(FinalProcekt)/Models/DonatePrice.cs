using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Models
{
    public class DonatePrice
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Donateee")]
        public int DonateId { get; set; }
        public Donate Donateee { get; set; }

        [ForeignKey("Priceee")]
        public int PriceId { get; set; }
        public Price Priceee { get; set; }
        
        [ForeignKey("Cause")]
        public int CauseId { get; set; }
        public Cause Cause { get; set; }
    }
}
