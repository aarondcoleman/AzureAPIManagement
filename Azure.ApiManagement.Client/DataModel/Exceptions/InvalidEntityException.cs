﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallStepsLabs.Azure.ApiManagement.Model
{
    public class InvalidEntityException : Exception
    {
        public InvalidEntityException(string message) : base(message) { }
    }
}