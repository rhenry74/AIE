
namespace AIE_Draw
{
    public interface GraphicElement
    {
        void DrawOn(Graphics graphics);
    }
    internal class DrawElementPropertyAttribute : Attribute
    {
    }
}