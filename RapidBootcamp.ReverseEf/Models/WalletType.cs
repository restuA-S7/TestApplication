﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace RapidBootcamp.ReverseEf.Models;

public partial class WalletType
{
    public int WalletTypeId { get; set; }

    public string WalletName { get; set; }

    public virtual ICollection<Wallet> Wallets { get; set; } = new List<Wallet>();
}