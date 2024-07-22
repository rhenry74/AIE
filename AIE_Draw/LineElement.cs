
using static System.Net.Mime.MediaTypeNames;

namespace AIE_Draw
{
    internal class LineElement: GraphicElement
    {
        private string text;

        [DrawElementProperty]
        public int X1 { get; set; }

        [DrawElementProperty]
        public int Y1 { get; set; }

        [DrawElementProperty]
        public int X2 { get; set; }

        [DrawElementProperty]
        public int Y2 { get; set; }

        private Pen pen;

        public LineElement()
        {
            pen = Pens.Black;
        }

        public LineElement(string text): this()
        {
            this.text = text;
        }

        public void DrawOn(Graphics graphics)
        {
            graphics.DrawLine(pen, X1, Y1, X2, Y2);
        }

        public override string ToString()
        {
            return $"Line: X1={X1}, Y1={Y1}, X2={X2}, Y2={Y2}";
        }
    }
}