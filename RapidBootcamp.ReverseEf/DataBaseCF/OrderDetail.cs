﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace RapidBootcamp.ReverseEf.DataBaseCF;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public string OrderHeaderId { get; set; }

    public int ProductId { get; set; }

    public int Qty { get; set; }

    public decimal Price { get; set; }

    public virtual OrderHeader OrderHeader { get; set; }

    public virtual Product Product { get; set; }
}