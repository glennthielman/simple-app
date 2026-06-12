// Test/ParkingServiceTests.cs
using Xunit;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Moq;

public class ParkingServiceTests
{
    [Fact]
    public async Task GetParkingsJsonAsync_ReturnsJsonContent()
    {
        // Arrange
        var tempFile = Path.GetTempFileName();
        var expectedJson = "{ \"test\": true }";
        await File.WriteAllTextAsync(tempFile, expectedJson);

        var envMock = new Mock<IWebHostEnvironment>();
        envMock.Setup(e => e.ContentRootPath)
               .Returns(Path.GetDirectoryName(tempFile)!);

        var service = new ParkingService(envMock.Object);

        // Override file path manually (simplification for test)
        typeof(ParkingService)
            .GetField("_filePath", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
            .SetValue(service, tempFile);

        // Act
        var result = await service.GetParkingsJsonAsync();

        // Assert
        Assert.Equal(expectedJson, result);
    }
}