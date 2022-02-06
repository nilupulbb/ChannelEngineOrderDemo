﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngineOrderDemo.Logic
{
    /*
     * Communication object of product information
     */
    public class ProductInfo
    {
        public string Description { set; get; }

        public string Gtin { set; get; }

        public float TotalQuantity { set; get; }

        public string MerchantProductNo { set; get; }

    }
}
