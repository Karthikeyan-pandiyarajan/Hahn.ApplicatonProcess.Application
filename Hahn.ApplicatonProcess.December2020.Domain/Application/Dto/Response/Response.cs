using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Domain.Application.Dto.Response
{
    public class Response<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
