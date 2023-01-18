using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }//T türünde, API'den gelen response daki json türündeki veriler
        public int StatusCode { get; set; }//API'de gönderilen isteklerin durum kodları
        public bool IsSuccesful { get; set; }//Response başarılı mı
        public List<string> Errors { get; set; }//Hata olması durumunda hataların listelendiği property
        public static ResponseDto<T> Success(T data, int statusCode)
        {
            return new ResponseDto<T>
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccesful = true
            };
        }

        public static ResponseDto<T> Success(int statusCode)
        {
            return new ResponseDto<T>
            {
                Data = default(T),
                StatusCode = statusCode,
                IsSuccesful = true
            };
        }
        public static ResponseDto<T> Fail(List<string> errors, int statusCode)
        {
            return new ResponseDto<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccesful = false
            };
        }
        public static ResponseDto<T> Fail(string error, int statusCode)
        {
            return new ResponseDto<T>
            {
                Errors = new List<string>() { error },//
                StatusCode = statusCode,
                IsSuccesful = false
            };
        }
    }
}
