﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitabase.Azure.ApiManagement.Swagger
{

    /// <summary>
    /// Contact information for the exposed API.
    /// </summary>
    public class Contact
    {
        [JsonProperty("name")]
        public string Name { get; set; }        // The license name used for the API.


        [JsonProperty("url")]
        public string Url { get; set; }         // A URL to the license used for the API. MUST be in the format of a URL.


        [JsonProperty("email")]
        public string Email { get; set; }
    }

}