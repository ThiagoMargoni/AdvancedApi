using System.Net;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

using AdvancedApi.Helpers;
using UnauthorizedAccessException = AdvancedApi.Helpers.UnauthorizedAccessException;
using NotImplementedException = AdvancedApi.Helpers.NotImplementedException;
using KeyNotFoundException = AdvancedApi.Helpers.KeyNotFoundException;

namespace AdvancedApi.Middlewares
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            string message;

            var exceptionType = exception.GetType();

            if (exceptionType == typeof(BadRequestException)) { status = HttpStatusCode.BadRequest; message = "Bad Request"; }

            else if (exceptionType == typeof(NotFoundException) || exceptionType == typeof(DbUpdateException) || exceptionType == typeof(DbUpdateConcurrencyException)) 
            { status = HttpStatusCode.NotFound; message = "Não Encontrado"; }

            else if (exceptionType == typeof(UnauthorizedAccessException)) { status = HttpStatusCode.Unauthorized; message = "Não Autorizado"; }

            else if (exceptionType == typeof(NotImplementedException)) { status = HttpStatusCode.NotImplemented; message = "Não Implementado"; }

            else if (exceptionType == typeof(KeyNotFoundException) || exceptionType == typeof(ArgumentNullException))
            { status = HttpStatusCode.NotFound; message = "Não Encontrado"; }

            else if (exceptionType == typeof(CannotInsertNull)) { status = HttpStatusCode.LengthRequired; message = "Não Inserir Nulo"; }

            else if (exceptionType == typeof(CannotInsertDuplicateKeyUniqueIndex))
            { status = HttpStatusCode.Ambiguous; message = "Campo Já Cadastrado"; }

            else if (exceptionType == typeof(ArithmeticOverflow)) { status = HttpStatusCode.NotAcceptable; message = "Tamanho Muito Grande"; }

            else if (exceptionType == typeof(StringOrBinaryDataWouldBeTruncated)) { status = HttpStatusCode.NotAcceptable; message = "Tamanho Muito Grande"; }

            else if (exceptionType == typeof(FormatException)) { status = HttpStatusCode.Conflict; message = "Erro de Formato"; }

            else if (exceptionType == typeof(OutOfStatus)) { status = HttpStatusCode.NotAcceptable; message = "Status Indevido"; }

            else { status = HttpStatusCode.InternalServerError; message = "Error Não Tratado"; }

            var exceptionResult = JsonSerializer.Serialize(new { error = message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;  

            return context.Response.WriteAsync(exceptionResult);
        }
    }
}
