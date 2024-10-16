using FibonacciApi.Application.FibonacciSequence.FibonacciSequence.Interfaces;
using System.Collections.Concurrent;

namespace FibonacciApi.Application.FibonacciSequence;

public class GetNthNumber : IGetNthNumber
{
    private readonly ConcurrentDictionary <int, int> fibonacciSequence = new();

    public GetNthNumber()
    {
        fibonacciSequence.TryAdd(0, 0);
        fibonacciSequence.TryAdd(1, 1);
    }

    public int Handle(int number)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(number);

        return CalculateNthNumber(number);
    }

    private int CalculateNthNumber(int number)
    {
        if(fibonacciSequence.TryGetValue(number, out int value))
        {
            return value;
        }

        value = CalculateNthNumber(number - 1) + CalculateNthNumber(number - 2);
        fibonacciSequence.TryAdd(number, value);

        return value;
    }
}
