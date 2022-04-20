using NUnit.Framework;
using KatasApp.Services;

namespace FizzBuzzTest;

public class FizzBuzzTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("1", 1)]
    [TestCase("2", 2)]
    [TestCase("Fizz", 3)]
    [TestCase("4", 4)]
    [TestCase("Buzz", 5)]
    [TestCase("Fizz", 6)]
    [TestCase("7", 7)]
    [TestCase("Fizz", 9)]
    [TestCase("Buzz", 10)]
    [TestCase("FizzBuzz", 15)]
    public void WhenPassNumberNotEqual3or5ReturnNumberToString(string expected, int numberToProcess)
    {
        Assert.AreEqual(expected, FizzBuzz.ProcessFizzBuzz(numberToProcess), $"When Pass { numberToProcess } should be { expected } ");
    }
}