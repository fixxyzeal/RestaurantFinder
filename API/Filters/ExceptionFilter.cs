using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Filters
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        private readonly MessageResult _messageResult;

        public ExceptionFilter(MessageResult messageResult)
        {
            _messageResult = messageResult;
        }

        //This global exception filter will help to provide exception information no need to write try catch in project

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            string exceptionMsg = string.Format("Controller:{0} | Action:{1} | Exception:{2}", context.RouteData.Values["controller"],
                context.RouteData.Values["action"], context.Exception.GetBaseException().ToString());

            _messageResult.Success = false;
            _messageResult.Message = exceptionMsg;

            await Task.Run(() => context.Result = new UnprocessableEntityObjectResult(_messageResult)).ConfigureAwait(false);
        }
    }
}