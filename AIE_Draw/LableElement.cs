
namespace AIE_Draw
{
    internal class LableElement: IGraphicElement
    {
        private string elementDef;

        [DrawElementProperty]
        public float X { get; set; }
        
        [DrawElementProperty]
        public float Y { get; set; }

        [DrawElementProperty] 
        public string Text { get; set; }

        private Font _font;
        private Brush _brush;

        public LableElement(string elementDef): this()
        {
            this.elementDef = elementDef;
        }

        public LableElement()
        {
            _font = SystemFonts.DefaultFont;
            _brush = Brushes.Black;
        }

        public void DrawOn(Graphics graphics)
        {
            graphics.DrawString(Text, _font, _brush, X, Y);
        }

        public override string ToString()
        {
            return $"Lable: X={X}, Y={Y}, Text={Text}";
        }
    }

    
}