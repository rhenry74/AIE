
namespace AIE_Draw
{
    internal class LableElement: GraphicElement
    {
        private string elementDef;

        [DrawElementProperty]
        public int X { get; set; }
        
        [DrawElementProperty]
        public int Y { get; set; }

        [DrawElementProperty] 
        public string Text { get; set; }

        public LableElement(string elementDef)
        {
            this.elementDef = elementDef;
        }

        public LableElement()
        {
        }

        public void DrawOn(Graphics graphics)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Lable: X={X}, Y={Y}, Text={Text}";
        }
    }

    
}