using Xunit;
using task05;
using System.Linq;
namespace task05tests;
public class TestClass
{
    public int PublicField = default!;
    private string _privateField = default!;
    public int Property { get; set; }
    public void Method() { }
    public void MethodWithParams(int a, string b) { }
}

[Serializable]
public class AttributedClass { }

public class ClassAnalyzerTests
{
    [Fact]
    public void GetPublicMethods_ShouldReturnAllPublicInstanceMethods()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));

        var methods = analyzer.GetPublicMethods().ToList();

        Assert.Contains("Method", methods);
        Assert.Contains("MethodWithParams", methods);
        Assert.DoesNotContain("PrivateMethod", methods);
    }

    [Fact]
    public void GetAllFields_ShouldIncludePublicAndPrivateFields()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));

        var fields = analyzer.GetAllFields();

        Assert.Contains("PublicField", fields);
        Assert.Contains("_privateField", fields);
        Assert.DoesNotContain("Property", fields);
    }

    [Fact]
    public void GetProperties_ShouldReturnAllPublicProperties()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));

        var props = analyzer.GetProperties();

        Assert.Contains("Property", props);
        Assert.Single(props);
    }

    [Fact]
    public void GetMethodParams_ShouldReturnParameterNamesForValidMethod()
    {

        var analyzer = new ClassAnalyzer(typeof(TestClass));

        var parameters = analyzer.GetMethodParams("MethodWithParams");

        Assert.Equal(new[] { "a", "b" }, parameters);
    }

    [Fact]
    public void GetMethodParams_ShouldReturnEmptyForInvalidMethod()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));

        var parameters = analyzer.GetMethodParams("NonExistentMethod");

        Assert.Empty(parameters);
    }

    [Fact]
    public void HasAttribute_ShouldReturnTrueWhenClassHasAttribute()
    {
        var analyzer = new ClassAnalyzer(typeof(AttributedClass));

        bool result = analyzer.HasAttribute<SerializableAttribute>();

        Assert.True(result);
    }

    [Fact]
    public void HasAttribute_ShouldReturnFalseWhenClassLacksAttribute()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));

        bool result = analyzer.HasAttribute<SerializableAttribute>();

        Assert.False(result);
    }
}
