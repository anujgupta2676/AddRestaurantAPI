using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AddRestaurantAPI.Models
{
    public class AddRestaurant
    {
        [Key]
        public int RestaurantId { get; set; }

        public String RestaurantName { get; set; }


        public String Address { get; set; }
       

        public String City { get; set; }

        public int Pincode { get; set; }


    }
}
