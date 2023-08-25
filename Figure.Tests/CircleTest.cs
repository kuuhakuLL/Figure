using Figure.Api.Domain.Figure;
using FluentAssertions;

namespace Figure.Tests;

public class CircleTest {
    [Fact]
    public void Get_circle_area_should_return_valid() {
        var circle = new Сircle(5);

        circle.CalcArea().Should().Be(78.539816339744831);
    }
}