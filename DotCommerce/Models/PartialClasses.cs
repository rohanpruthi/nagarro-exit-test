﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotCommerce.Models
{
    [MetadataType(typeof(PersonMetadata))]
    public partial class Person
    {
    }

    [MetadataType(typeof(ProductMetadata))]
    public partial class Product
    {
    }
}