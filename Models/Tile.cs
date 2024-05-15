using Avalonia.Media.Imaging;
namespace MVVM_Baraja.Models;

public record Tile(int Size,  int TopX, int TopY, string Imagen, Bitmap Img);

// lo mismo pero escrito de forma clásica

public class Tile2(int s, int x, int y, string img, Bitmap img2)
{
    public int Size { get; set; } = s;
    public int TopX { get; set; } = x;
    public int TopY { get; set; } = y;

    public string Imagen { get; set; } = img;
    public Bitmap Img { get; set; } = img2;
}
