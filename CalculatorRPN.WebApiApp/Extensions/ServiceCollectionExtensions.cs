using CalculatorRPN.Application.Contracts;
using CalculatorRPN.Application.Domain;
using CalculatorRPN.Application.Services;
using CalculatorRPN.WebApi.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CalculatorRPN.WebApiApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IMvcBuilder AddCalculatorService(this IServiceCollection services)
        {
            services.AddSingleton<ICalculatorService, CalculatorService>();
            services.AddSingleton<ICalculatorStack, CalculatorStack>();

            var calculatorControllerAssembly = typeof(CalculatorController).GetTypeInfo().Assembly;
            var mvcBuilder =
                services
                    .AddMvc()
                    .AddApplicationPart(calculatorControllerAssembly)
                    .AddControllersAsServices();

            return mvcBuilder;
        }
    }
}
