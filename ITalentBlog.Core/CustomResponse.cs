using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ITalentBlog.Core
{
    public class CustomResponse<T>
    {
        public T Data { get; set; }

        public List<string> Errors { get; set; }

        [JsonIgnore]
        public int Status { get; set; }

        public static CustomResponse<T> Success(T Data, int status)
        {

            return new CustomResponse<T>() { Data = Data, Status = status };
        }


        public static CustomResponse<T> Fail(List<string> errors, int status)
        {
            return new CustomResponse<T>() { Errors = errors, Status = status };
        }

        public static CustomResponse<T> Fail(List<string> errors)
        {
            return new CustomResponse<T>() { Errors = errors };
        }

    }
}
