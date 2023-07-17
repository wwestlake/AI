using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AITesting
{
    public static class ResultExtensions
    {

        private static Action<List<IError>> defaultFail = errList =>
        {
            foreach (var err in errList)
            {
                Console.WriteLine(err.Message);
            }
        };

        public static Action<List<IError>> DefaultFail { get => defaultFail; set => defaultFail = value; }

        public static void Process<T>(this Result<T> result, Action<T> onSuccess, Action<List<IError>> onFailure)
        {
            if (result.IsSuccess) onSuccess(result.Value);
            else onFailure(result.Errors);
        }

        public static void Process<T>(this Result<T> result, Action<T> onSuccess)
        {
            if (result.IsSuccess) onSuccess(result.Value);
            else
            {
                DefaultFail(result.Errors);
            }
        }


    }
}
