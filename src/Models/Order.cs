﻿using System;

#if SERVICE
using Microsoft.WindowsAzure.Mobile.Service;
#endif

namespace XamarinCRM.Models
{
    public class Order : 
#if SERVICE
        EntityData
#else
        BaseModel
#endif
    {
        public Order()
        {
            AccountId = string.Empty;

            //New orders default to open status. 
            IsOpen = true;
            Item = string.Empty;
            OrderDate = DateTime.UtcNow;
            ClosedDate = null; // Is never shown unless order is closed, in which case this should have a sane value.
            DueDate = DateTime.UtcNow.AddDays(7);
            Price = 0;
        }

        public bool IsOpen { get; set; }
        public string AccountId { get; set; }
        public double Price { get; set; }
        public string Item { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ClosedDate { get; set; }

#if !SERVICE
        public string Status
        {
            get { return (IsOpen) ? "Open Orders" : "Delivered Orders"; }

        }
#endif
    }
}
