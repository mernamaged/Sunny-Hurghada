﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Sunny_Hurghada.Models;

public partial class SpotBooking
{
    public int Id { get; set; }

    public int PaymentId { get; set; }

    public int SpotId { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public DateTime TripDate { get; set; }

    public int Adults { get; set; }

    public int Children { get; set; }

    public string Nationality { get; set; }

    public string Phone { get; set; }

    public string SpecialRequest { get; set; }

    public virtual Payment Payment { get; set; }

    public virtual Spot Spot { get; set; }
}