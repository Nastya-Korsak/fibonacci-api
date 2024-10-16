using FibonacciApi.Application.FibonacciSequence;

namespace FibonacciApi.Tests;

public class GetNthNumberTests
{
    private readonly GetNthNumber _sut;

    public GetNthNumberTests()
    {
        _sut = new GetNthNumber();
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(4, 3)]
    [InlineData(5, 5)]
    [InlineData(6, 8)]
    [InlineData(10, 55)]
    public void Handle_ValidInput_ShouldReturnCorrectFibonacciNumber(int input, int expected)
    {
        // Act
        var result = _sut.Handle(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Handle_NegativeInput_ShouldThrowArgumentOutOfRangeException()
    {
        // Arrange
        int input = -1;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Handle(input));
    }
}
