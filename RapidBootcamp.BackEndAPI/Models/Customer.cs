﻿namespace RapidBootcamp.BackEndAPI.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null;
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public IEnumerable<Wallet> Wallets { get; set; }
    }
}
