using System;
using System.Collections.Generic;

namespace Square
{
    public class Points
    {
        public static Points _instance;

        List<int> vals = null;
        List<Point> ps = new List<Point>();
        List<int> shuffleResult = new List<int>();

        public int width = 0;
        public int height = 0;

        protected Points()
        {
        }

        public static Points Instance()
        {
            if(_instance == null) 
            {
                _instance = new Points();
            }
            return _instance;
        }

        public List<int> Init(int w)
        {
            this.vals = new List<int>();
            shuffleResult = new List<int>();
            this.width = w;
            this.height = w;

            List<int> nums = new List<int>();
            for(int i=1;i <= (this.width*this.width); i++)
            {
                nums.Add(i);
            }

            Shuffle(nums);

            this.vals = shuffleResult;

            if(this.vals.Count < (this.width * this.height))
            {
                throw new Exception("value length is too low");
            }

            SetValue();

            return this.vals;
        }

        public List<int> GetValues()
        {
            return this.vals;
        }

        private void SetValue()
        {
            int k = 0;
            for(int i = 1; i <= this.width; i++)
            {
                for(int j = 1; j <= this.height; j++)
                {
                    ps.Add( new Point(i, j , this.vals[k]) );
                    k++;
                }
            }
        }

        public Point GetPoint(int x, int y)
        {
            var p = ps.Find(a => a.x == x && a.y == y);
            
            return p;
        }

        public void MoveTo(Point p1, int moveToX, int moveToY)
        {
            Point p2 = GetPoint(moveToX, moveToY);
            
            Swap(p1, p2);
        }

        public void Swap(Point p1, Point p2)
        {
            if(p1 == null || p2 == null) throw new Exception("point is null");

            object temp = p1.value;

            p1.value = p2.value;
            p2.value = temp;

            Console.WriteLine("is match: " + this.IsMatch());
        }

        public void Swap(int x1, int y1, int x2, int y2)
        {
            Point p1 = GetPoint(x1, y1);
            Point p2 = GetPoint(x2, y2);

            Swap(p1, p2);
        }

        public int Sum(string vh, int line)
        {
            int sum = 0;

            if(line < 1 || line > this.height) return sum;

            if(vh == "V")
            {
                for(int v=1; v <= this.height; v++)
                {
                    Point p = GetPoint(v, line);
                    sum = sum + int.Parse(p.value.ToString());
                }
            }
            else
            {
                for(int h=1; h <= this.width; h++)
                {
                    Point p = GetPoint(line, h);
                    sum = sum + int.Parse(p.value.ToString());
                }
            }
            return sum;
        }

        public bool IsMatch()
        {
            int sum = 0;

            for(int i = 1; i <= this.width; i++)
            {
                int _sum = this.Sum("V", i);
                if(sum > 0 && sum != _sum) return false;
                sum = _sum;
            }

            for(int i = 1; i <= this.height; i++)
            {
                int _sum = this.Sum("H", i);
                if(sum > 0 && sum != _sum) return false;
                sum = _sum;
            }

            return true;
        }

        void Shuffle(List<int> source)
        {            
            int len = source.Count;
            if(len < 1) return;

            Random r = new Random();
            int rn = r.Next(0, len);
            int num = source[rn];

            if( source.Remove(num) )
            {
                shuffleResult.Add(num);
            }

            Shuffle(source);
        }

        public (IEnumerable<int>, string) getTubleTest() 
        {
            return (new List<int>() { 10,20,30 }, "test");
        }
    }
}