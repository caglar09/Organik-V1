using System;
using System.Collections.Generic;
using System.Text;

namespace OrganikV1.Common
{
   public class ServiceResponse
    {
        public bool success { get; set; }
        public int? total_count { get; set; }
        public dynamic result { get; set; }
        public string message { get; set; }
        public bool show { get; set; }


        public static ServiceResponse GetSuccess(dynamic ResultData, string successMessage)
        {
            return new ServiceResponse
            {
                success = true,
                result = ResultData,
                message = successMessage,
            };
        }
        public static ServiceResponse GetSuccess(dynamic ResultData, int totalCount, string successMessage)
        {
            return new ServiceResponse
            {
                success = true,
                result = ResultData,
                total_count = totalCount,
                message = successMessage,
            };
        }
        public static ServiceResponse GetError(string errorMessage)
        {
            return new ServiceResponse
            {
                message = errorMessage,
                success = false,
                result = "",
            };
        }
    }
}
