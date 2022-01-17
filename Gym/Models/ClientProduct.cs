using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class ClientProduct
    {
        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ClientId { get; set; }

        public Product Product { get; set; }
        public Client Client { get; set; }
    }
}