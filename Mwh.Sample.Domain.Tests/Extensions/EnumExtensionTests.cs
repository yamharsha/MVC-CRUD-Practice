namespace Mwh.Sample.Domain.Tests.Extensions;

// <summary>
/// Defines test class EnumExtensionTests.
/// </summary>
[TestClass]
public class EnumExtensionTests
{


    [TestMethod]
    public void GetDescription_WithEnumValue_ReturnsDescription()
    {
        // Arrange
        TestEnum enumValue = TestEnum.First;

        // Act
        string description = enumValue.GetDescription();

        // Assert
        Assert.AreEqual("The First One", description);
    }

    [TestMethod]
    public void GetDescription_WithEnumValueWithoutDescription_ReturnsEnumValueToString()
    {
        // Arrange
        TestEnum enumValue = TestEnum.Second;

        // Act
        string description = enumValue.GetDescription();

        // Assert
        Assert.AreEqual("Second", description);
    }

    [TestMethod]
    public void GetDescription_WithNullEnum_ReturnsEmptyString()
    {
        // Arrange
        TestEnum? enumValue = null;

        // Act
        string description = enumValue.GetDescription();

        // Assert
        Assert.AreEqual(string.Empty, description);
    }








    /// <summary>
    /// Defines the test method EnumGetDisplayName_ExpectedBehavior.
    /// </summary>
    [TestMethod]
    public void EnumGetDescription_NullEnum()
    {
        // Arrange
        TestEnum? myTest = null;

        // Act
        var result = myTest.GetDescription();

        // Assert
        Assert.AreEqual(result, string.Empty);
    }
    /// <summary>
    /// Defines the test method EnumGetDisplayName_ExpectedBehavior.
    /// </summary>
    [TestMethod]
    public void EnumGetDisplayName_ExpectedBehavior()
    {
        // Arrange
        var myTest = TestEnum.First;

        // Act
        var result = myTest.GetDisplayName();

        // Assert
        Assert.AreEqual(result, "1st");
    }
    /// <summary>
    /// Defines the test method EnumGetDisplayNameMissingDisplayName.
    /// </summary>
    [TestMethod]
    public void EnumGetDisplayName_Null()
    {
        // Arrange
        TestEnum? myTest = null;

        // Act
        var result = myTest.GetDisplayName();

        // Assert
        Assert.AreEqual(result, string.Empty);
    }
    /// <summary>
    /// Defines the test method EnumGetDisplayNameMissingDisplayName.
    /// </summary>
    [TestMethod]
    public void EnumGetDescriptionMissingDisplayName()
    {
        // Arrange
        var myTest = TestEnum.Second;

        // Act
        var result = myTest.GetDescription();

        // Assert
        Assert.AreEqual(result, "Second");
    }
    /// <summary>
    /// Defines the test method EnumGetDisplayNameMissingDisplayName.
    /// </summary>
    [TestMethod]
    public void EnumGetDisplayNameMissingDisplayName()
    {
        // Arrange
        var myTest = TestEnum.Second;

        // Act
        var result = myTest.GetDisplayName();

        // Assert
        Assert.AreEqual(result, "Second");
    }
    /// <summary>
    /// Defines the test method EnumGetDisplayNameExpectedBehavior.
    /// </summary>
    [TestMethod]
    public void EnumToDescriptionString_ExpectedBehavior()
    {
        // Arrange
        var myTest = TestEnum.First;

        // Act
        var result = myTest.GetDescription();

        // Assert
        Assert.AreEqual(result, "The First One");
    }
    /// <summary>
    /// Defines the test method EnumToDictionaryExpectedBehavior.
    /// </summary>
    [TestMethod]
    public void EnumToDictionaryExpectedBehavior()
    {
        // Arrange
        var myTest = TestEnum.First;

        // Act
        var result = myTest.ToDictionary();

        // Assert
        Assert.AreEqual(result.Count, 3);
    }

    [TestMethod]
    public void GetAllValues_ReturnsAllEnumValues()
    {
        // Arrange
        var myTest = TestEnum.First;

        // Act
        var values = EnumExtension.GetAllValues<TestEnum>();

        // Assert
        Assert.AreEqual(3, values.Count());
        CollectionAssert.Contains(values.ToList(), TestEnum.First);
        CollectionAssert.Contains(values.ToList(), TestEnum.Second);
    }

    [TestMethod]
    public void ParseCaseInsensitive_ParsesEnumValueCaseInsensitive()
    {
        // Arrange
        var myTest = TestEnum.First;

        // Act
        var value = EnumExtension.ParseCaseInsensitive<TestEnum>("fIrSt");

        // Assert
        Assert.AreEqual(TestEnum.First, value);
    }

    [TestMethod]
    public void GetNames_ReturnsAllEnumNames()
    {
        // Arrange
        var myTest = TestEnum.First;

        // Act
        var names = EnumExtension.GetNames<TestEnum>();

        // Assert
        Assert.AreEqual(3, names.Length);
        CollectionAssert.Contains(names, "First");
        CollectionAssert.Contains(names, "Second");
    }

    [TestMethod]
    public void GetUnderlyingType_ReturnsEnumUnderlyingType()
    {
        // Arrange
        var myTest = TestEnum.First;

        // Act
        var underlyingType = EnumExtension.GetUnderlyingType<TestEnum>();

        // Assert
        Assert.AreEqual(typeof(Int32), underlyingType);

    }

    [TestMethod]
    public void IsDefined_WithDefinedEnumValue_ReturnsTrue()
    {
        // Arrange
        TestEnum enumValue = TestEnum.First;

        // Act
        bool isDefined = enumValue.IsDefined();

        // Assert
        Assert.IsTrue(isDefined);
    }

    [TestMethod]
    public void IsDefined_WithUndefinedEnumValue_ReturnsFalse()
    {
        // Arrange
        TestEnum enumValue = (TestEnum)42; // An undefined enum value

        // Act
        bool isDefined = enumValue.IsDefined();

        // Assert
        Assert.IsFalse(isDefined);
    }


    [TestMethod]
    public void GetDisplayName_WithEnumValue_ReturnsDisplayName()
    {
        // Arrange
        TestEnum enumValue = TestEnum.First;

        // Act
        string displayName = enumValue.GetDisplayName();

        // Assert
        Assert.AreEqual("1st", displayName);
    }

    [TestMethod]
    public void GetDisplayName_WithEnumValueWithoutDisplayName_ReturnsEnumValueToString()
    {
        // Arrange
        TestEnum enumValue = TestEnum.Second;

        // Act
        string displayName = enumValue.GetDisplayName();

        // Assert
        Assert.AreEqual("Second", displayName);
    }

    [TestMethod]
    public void GetDisplayName_WithNullEnum_ReturnsEmptyString()
    {
        // Arrange
        TestEnum? enumValue = null;

        // Act
        string displayName = enumValue.GetDisplayName();

        // Assert
        Assert.AreEqual(string.Empty, displayName);
    }









}
