
namespace AIE_Draw
{
    internal class LineElement: GraphicElement
    {
        private string text;

        public LineElement()
        {
        }

        public LineElement(string text)
        {
            this.text = text;
        }

        public void DrawOn(Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }
}