﻿using Fitabase.Azure.ApiManagement.DataModel.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitabase.Azure.ApiManagement.Model
{   
    public class APIOperation : EntityBase
    {
        protected override string UriIdFormat => "/operations";
        public static string GenerateIdSignature()
        {
            return new StringBuilder()
                        .Append("APIOperation_")
                        .Append(Guid.NewGuid().ToString("N"))
                        .ToString();
        }


        public APIOperation() { }
        public APIOperation(string id, string name, 
                            RequestMethod method, string urlTemplate, 
                            List<TemplateParameter> parameters,
                            RequestContract request)
        {
            if (String.IsNullOrWhiteSpace(id))
                throw new ArgumentException("APIOperation id is required");
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("APIOperation name is required");
            if (method == null)
                throw new ArgumentException("APIOperation method is required");
            
            this.Id = id;
            this.Name = name;
            this.Method = method.ToString();
            this.UrlTemplate = urlTemplate;
            this.TemplateParameter = parameters;
            this.Request = request;
        }


        // Name of the operation
        [JsonProperty("name")]
        public string Name { get; set; }

        // A valid HTTP Operation Method
        [JsonProperty("method")]
        public string Method { get; set; }

        // Relative URL template identifying the target resource for this operation
        [JsonProperty("urlTemplate")]
        public string UrlTemplate { get; set; }         

        // Collection of URL template parameters
        // E.g calc.com/sum?a=5&b=10
        [JsonProperty("templateParameters")]
        public List<TemplateParameter> TemplateParameter { get; set; }

        // Description of the operation. May include HTML formatting tags.
        [JsonProperty("description")]
        public string Description { get; set; }

        // An entity containing request details
        [JsonProperty("request")]
        public RequestContract Request { get; set; }

        [JsonProperty("responses")]
        public OperationResponse[] Responses { get; set; }


        /// <summary>
        /// Contain operation response
        /// </summary>
        public class OperationResponse
        {

            public OperationResponse(int statusCode, string description)
            {
                this.StatusCode = statusCode;
                this.Description = description;
            }


            [JsonProperty("statusCode")]
            public int StatusCode { get; set; }
            
            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("representations")]
            public List<Representation> Representations { get; set; }


            /// <summary>
            /// Operation response representation
            /// </summary>
            public class Representation
            {
                [JsonProperty("contentType")]
                public string ContenType { get; set; }

                [JsonProperty("sample")]
                public string Sameple { get; set; }
            }
        }
    }



    /// <summary>
    /// This class containing request details
    /// </summary>
    public class RequestContract
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("queryParameters")]
        public List<QueryParameter> QueryParameters { get; set; }

        [JsonProperty("headers")]
        public List<RequestHeader> Headers { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class RequestHeader
    {
        public RequestHeader(string name, ParameterType type, string defaultValue = null)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("RequestHeader name is required");
            this.Name = name;
            this.Type = TemplateParameterType.GetType(type);
            this.DefaultValue = defaultValue;
        }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("defaultValue")]
        public string DefaultValue { get; set; }
        [JsonProperty("required")]
        public bool Required { get; set; }
        [JsonProperty("values")]
        public string[] Values { get; set; }
    }

    
    /// <summary>
    /// TODO not so sure what query parameter does...
    /// </summary>
    public class QueryParameter
    {
        public QueryParameter(string name, ParameterType type)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("QueryParameter name is required");
            this.Name = name;
            this.Type = TemplateParameterType.GetType(type);
        }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("defaultValue")]
        public string DefaultValue { get; set; }
        [JsonProperty("values")]
        public string[] Values { get; set; }
    }


    /// <summary>
    /// This class represent a URL template parameter.
    /// E.x calc.com/sum?a=5&b=10
    /// </summary>
    public class TemplateParameter
    {
        public TemplateParameter(string name, ParameterType type)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("TemplateParameter name is required");
            this.Name = name;
            this.Type = TemplateParameterType.GetType(type);
        }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("defaultValue")]
        public string DefaultValue { get; set; }
        [JsonProperty("values")]
        public string[] Values { get; set; }

    }
}
