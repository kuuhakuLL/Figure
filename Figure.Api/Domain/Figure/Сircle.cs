namespace Figure.Api.Domain.Figure; 

public class Сircle : IFigure {
    public double Radius { get; private set; }

    public Сircle(double radius) {
        Radius = radius;
    }
    public double CalcArea() => 
        Math.PI * Math.Pow(Radius, 2);
}