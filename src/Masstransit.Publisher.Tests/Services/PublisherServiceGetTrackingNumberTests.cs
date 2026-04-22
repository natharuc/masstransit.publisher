using Masstransit.Publisher.Domain.Classes;
using Masstransit.Publisher.Services.Services;

namespace Masstransit.Publisher.Tests.Services;

public class PublisherServiceGetTrackingNumberTests
{
    private static readonly Guid ValidGuid = new("6675b43c-5965-4370-ba3f-8bdf90414e21");

    private static PublisherService CreateService() =>
        new(new LogService());

    private static ActivitySettings Settings(string property = "Identificador") =>
        new() { TrackingNumberProperty = property };

    [Fact]
    public void ReturnsGuid_WhenIdentificadorIsAtRoot_PascalCase()
    {
        var json = $$"""
            {
              "Identificador": "{{ValidGuid}}",
              "Processo": { "Numero": 123 }
            }
            """;

        var result = CreateService().GetTrackingNumber(json, Settings());

        Assert.Equal(ValidGuid, result);
    }

    [Fact]
    public void ReturnsGuid_WhenIdentificadorIsAtRoot_CamelCase()
    {
        var json = $$"""
            {
              "identificador": "{{ValidGuid}}",
              "processo": { "numero": 123 }
            }
            """;

        var result = CreateService().GetTrackingNumber(json, Settings());

        Assert.Equal(ValidGuid, result);
    }

    [Fact]
    public void ReturnsGuid_WhenIdentificadorIsAtRootButAtEnd_WithNestedNonGuidIdentificador()
    {
        var json = $$"""
            {
              "coberturas": [
                {
                  "identificador": "860001992203362",
                  "descricao": "INVALIDEZ PERM."
                }
              ],
              "identificador": "{{ValidGuid}}"
            }
            """;

        var result = CreateService().GetTrackingNumber(json, Settings());

        Assert.Equal(ValidGuid, result);
    }

    [Fact]
    public void ReturnsGuid_WhenIdentificadorIsAtRootAtBeginning_WithNestedNonGuidIdentificador()
    {
        var json = $$"""
            {
              "Identificador": "{{ValidGuid}}",
              "Coberturas": [
                {
                  "Identificador": "860001992203362",
                  "Descricao": "INVALIDEZ PERM."
                }
              ]
            }
            """;

        var result = CreateService().GetTrackingNumber(json, Settings());

        Assert.Equal(ValidGuid, result);
    }

    [Fact]
    public void ReturnsGuid_WhenPropertyNameIsCaseInsensitive()
    {
        var json = $$"""{ "IDENTIFICADOR": "{{ValidGuid}}" }""";

        var result = CreateService().GetTrackingNumber(json, Settings("identificador"));

        Assert.Equal(ValidGuid, result);
    }

    [Fact]
    public void Throws_WhenJsonIsEmpty()
    {
        var ex = Assert.Throws<InvalidOperationException>(
            () => CreateService().GetTrackingNumber(string.Empty, Settings()));

        Assert.Equal("Json is required to get the tracking number", ex.Message);
    }

    [Fact]
    public void Throws_WhenTrackingNumberPropertyNotConfigured()
    {
        var json = $$"""{ "Identificador": "{{ValidGuid}}" }""";

        var ex = Assert.Throws<InvalidOperationException>(
            () => CreateService().GetTrackingNumber(json, new ActivitySettings()));

        Assert.Equal("Activity settings is required to get the tracking number", ex.Message);
    }

    [Fact]
    public void Throws_WhenRootIdentificadorIsNotAGuid()
    {
        var json = """{ "Identificador": "not-a-guid" }""";

        var ex = Assert.Throws<InvalidOperationException>(
            () => CreateService().GetTrackingNumber(json, Settings()));

        Assert.Equal("Tracking number is invalid", ex.Message);
    }

    [Fact]
    public void Throws_WhenPropertyNotFoundAnywhere()
    {
        var json = """{ "Outro": "valor" }""";

        var ex = Assert.Throws<InvalidOperationException>(
            () => CreateService().GetTrackingNumber(json, Settings()));

        Assert.Equal("Tracking number property not found", ex.Message);
    }
}
