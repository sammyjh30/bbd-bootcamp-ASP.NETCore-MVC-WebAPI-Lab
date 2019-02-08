using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Models
{
    public class CustomerItem
    {
        // If you have a custom ID need to use the key attribute to tell it this is the key
        //Also
        // using System.ComponentModel.DataAnnotations;
        [Key]
        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalAddress { get; set; }

    }
}