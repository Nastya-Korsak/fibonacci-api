using FibonacciApi.Application.FibonacciSequence;
using FibonacciApi.Application.FibonacciSequence.FibonacciSequence.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FibonacciApi.Application;

public static class DependencyInjection
{
    public static void AddFibonacciServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IGetNthNumber, GetNthNumber>();
    }
}
