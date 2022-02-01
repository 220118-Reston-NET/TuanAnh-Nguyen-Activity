using Xunit;
using PokeModel;

namespace PokeTest
{
  public class AbilityModelTest
  {
    /// <summary>
    /// Check the validation for PP property for valid data
    /// </summary>
    /// [Fact] is a data annotation in C# and all it means is it will tell the compiler that this specific method is a unit test
    [Fact]
    public void PPShouldSetValidData()
    {
      // Arrange
      Ability abi = new Ability();
      int validPP = 10;

      // Act
      abi.PP = validPP;

      // Assert
      Assert.NotNull(abi.PP); //checks that the property is not null meaning we did set data in this property
      Assert.Equal(validPP, abi.PP); //checks if the property does indeed hold the same value as what we set it as
    }

    /// <summary>
    /// Checks validation for PP property with incorrect data
    /// Should throw an exception
    /// </summary>
    [Theory] //Changes the unit test to be parameterized and run multiple data and ensure they all passes
    [InlineData(-10)]
    [InlineData(-100)]
    [InlineData(-159800)]
    public void PPShouldFailSetInvalidData(int p_invalidPP)
    {
      // Arrange
      Ability abi = new Ability();

      // Act & Assert
      Assert.Throws<System.Exception>(
        () => abi.PP = p_invalidPP
      );
    }
  }
}

