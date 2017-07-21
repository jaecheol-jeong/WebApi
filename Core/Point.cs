namespace Square
{
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }

        public object value { get; set; }

        public Point()
        {
            this.x = -1;
            this.y = -1;
            this.value = null;
        }

        public Point(int x, int y, object v)
        {
            this.x = x;
            this.y = y;
            this.value = v;
        }

        public bool IsEmpty()
        {
            return (this.value == null);
        }

        /*public override string ToString()
        {
            return string.Format("{'x':'{0}','y':'{1}','value':'{2}'}", x, y, value ?? "");
        }*/

        public override string ToString() => $"x:{x}, y:{y}, value:{value}";
    }
}