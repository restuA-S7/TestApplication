﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace RapidBootcamp.ETLSampel.RapidDb;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; }

    public string Address { get; set; }

    public string City { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public virtual ICollection<Wallet> Wallets { get; set; } = new List<Wallet>();
}