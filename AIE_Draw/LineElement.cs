
using static System.Net.Mime.MediaTypeNames;

namespace AIE_Draw
{
    internal class LineElement: IGraphicElement
    {
        private string text;

        [DrawElementProperty]
        public float X1 { get; set; }

        [DrawElementProperty]
        public float Y1 { get; set; }

        [DrawElementProperty]
        public float X2 { get; set; }

        [DrawElementProperty]
        public float Y2 { get; set; }

        private Pen _pen;

        public LineElement()
        {
            _pen = Pens.Black;
        }

        public LineElement(string text): this()
        {
            this.text = text;
        }

        public void DrawOn(Graphics graphics)
        {
            graphics.DrawLine(_pen, X1, Y1, X2, Y2);
        }

        public override string ToString()
        {
            return $"Line: X1={X1}, Y1={Y1}, X2={X2}, Y2={Y2}";
        }
    }
}