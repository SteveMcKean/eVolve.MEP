using eVolve.MEP;
using Xunit;

namespace eVolve.MEP.Tests;

public class EvenNumberPrinterTests
{
    private string CaptureOutput(Action action)
    {
        var originalOut = Console.Out;
        using var writer = new StringWriter();
        Console.SetOut(writer);
        
        action();
        
        Console.SetOut(originalOut);
        return writer.ToString().Trim();
    }

    private string[] GetOutputLines(Action action)
    {
        var output = CaptureOutput(action);
        if (string.IsNullOrEmpty(output))
            return Array.Empty<string>();
        return output.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
    }

    [Fact]
    public void Print_Given4And17_Returns4_8_12_16()
    {
        // Arrange & Act
        var lines = GetOutputLines(() => EvenNumberPrinter.Print(17, 4));

        // Assert
        Assert.Equal(4, lines.Length);
        Assert.Equal("4", lines[0]);
        Assert.Equal("8", lines[1]);
        Assert.Equal("12", lines[2]);
        Assert.Equal("16", lines[3]);
    }

    [Fact]
    public void Print_ParametersReversed_StillWorks()
    {
        // lowest and highest swapped - should produce same result
        var output1 = CaptureOutput(() => EvenNumberPrinter.Print(17, 4));
        var output2 = CaptureOutput(() => EvenNumberPrinter.Print(4, 17));

        Assert.Equal(output1, output2);
    }

    [Fact]
    public void Print_OddLowest_ReturnsEvenMultiplesOnly()
    {
        // Given 3 and 17: even numbers divisible by 3 are 6, 12
        var lines = GetOutputLines(() => EvenNumberPrinter.Print(17, 3));

        Assert.Equal(2, lines.Length);
        Assert.Equal("6", lines[0]);
        Assert.Equal("12", lines[1]);
    }

    [Fact]
    public void Print_Given5And20_Returns10_20()
    {
        var lines = GetOutputLines(() => EvenNumberPrinter.Print(20, 5));

        Assert.Equal(2, lines.Length);
        Assert.Equal("10", lines[0]);
        Assert.Equal("20", lines[1]);
    }

    [Fact]
    public void Print_LowestIs2_ReturnsAllEvenNumbers()
    {
        // Every even number is divisible by 2
        var lines = GetOutputLines(() => EvenNumberPrinter.Print(10, 2));

        Assert.Equal(5, lines.Length);
        Assert.Equal("2", lines[0]);
        Assert.Equal("4", lines[1]);
        Assert.Equal("6", lines[2]);
        Assert.Equal("8", lines[3]);
        Assert.Equal("10", lines[4]);
    }

    [Fact]
    public void Print_SameEvenNumber_ReturnsIt()
    {
        var lines = GetOutputLines(() => EvenNumberPrinter.Print(4, 4));

        Assert.Single(lines);
        Assert.Equal("4", lines[0]);
    }

    [Fact]
    public void Print_SameOddNumber_ReturnsNothing()
    {
        var lines = GetOutputLines(() => EvenNumberPrinter.Print(5, 5));

        Assert.Empty(lines);
    }

    [Fact]
    public void Print_NoMatchesInRange_ReturnsNothing()
    {
        // Range 7-9, lowest is 7: even number is 8, but 8 % 7 != 0
        var lines = GetOutputLines(() => EvenNumberPrinter.Print(9, 7));

        Assert.Empty(lines);
    }

    [Fact]
    public void Print_EvenLowest6_ReturnsMultiplesOf6()
    {
        // lowest = 6, range to 24: multiples are 6, 12, 18, 24 (all even)
        var lines = GetOutputLines(() => EvenNumberPrinter.Print(24, 6));

        Assert.Equal(4, lines.Length);
        Assert.Equal("6", lines[0]);
        Assert.Equal("12", lines[1]);
        Assert.Equal("18", lines[2]);
        Assert.Equal("24", lines[3]);
    }

    [Fact]
    public void Print_LargeRange_ReturnsCorrectMultiples()
    {
        // 4 to 100: multiples of 4 that are even (all of them)
        var lines = GetOutputLines(() => EvenNumberPrinter.Print(100, 4));

        // 4, 8, 12, ..., 100 = 25 numbers
        Assert.Equal(25, lines.Length);
        Assert.Equal("4", lines[0]);
        Assert.Equal("100", lines[^1]);
    }

    [Fact]
    public void Print_Given21And7_Returns14()
    {
        // Requirement example 2
        var lines = GetOutputLines(() => EvenNumberPrinter.Print(21, 7));

        Assert.Single(lines);
        Assert.Equal("14", lines[0]);
    }

    [Fact]
    public void Print_Given3And10_Returns6()
    {
        // Requirement example 4
        var lines = GetOutputLines(() => EvenNumberPrinter.Print(10, 3));

        Assert.Single(lines);
        Assert.Equal("6", lines[0]);
    }

    [Fact]
    public void Print_Given2And2_Returns2()
    {
        // Requirement example 5
        var lines = GetOutputLines(() => EvenNumberPrinter.Print(2, 2));

        Assert.Single(lines);
        Assert.Equal("2", lines[0]);
    }
}
