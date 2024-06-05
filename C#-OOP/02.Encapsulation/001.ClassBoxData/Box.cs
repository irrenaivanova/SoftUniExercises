using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001.ClassBoxData
{
    public class Box
    {
		private double length;
        private double width;
        private double height;
        public Box()
        {
           
        }
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
		{
			get { return length; }
			private set
			{ 
				if (value<=0)
				{
					throw new ArgumentException("Length cannot be zero or negative.");
				}
				length = value; 
			}
		}
        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value;
            }
        }
        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                height = value;
            }
        }
        public double SurfaceArea()
        {
            return LateralSurfaceArea()+Length*Width*2;
        }
        public double LateralSurfaceArea()
        {
            return (Length+Width)*2*Height;
        }
        public double Volume()
        {
            return Width * Height*Length;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {Volume():f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
