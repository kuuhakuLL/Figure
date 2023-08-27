namespace Figure.Api.Domain.Figure; 

public class Сircle : IFigure {
    public FigureType Type { get; }
    public double Radius { get; private set; }

    public Сircle(double radius) {
        Radius = radius;
    }
}