using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCalculator
{
    public class Map
    {
        // map coord system:
        //     0  1  2  X
        //  0
        //  1
        //  2
        //  Y

        public record Point(int X, int Y, double Value);

        public List<Point> Points = new List<Point>();
        public int CollumnsCount = 0;
        public int RowsCount = 0;

        public List<double> XAxis = new List<double>();
        public List<double> YAxis = new List<double>();

        public double GetValue(double XValue, double YValue)
        {
            int xMap = 0;
            for (int x = 0; x < XAxis.Count; x++)
            {
                if (XValue.CompareTo(XAxis[x]) < 0.0)
                {
                    xMap = x;
                    break;
                }
            }

            int yMap = 0;
            for (int y = 0; y < YAxis.Count; y++)
            {
                if (YValue.CompareTo(YAxis[y]) < 0.0)
                {
                    yMap = y;
                    break;
                }
            }

            return Points.First(x => x.X == xMap && x.Y == yMap).Value;
        }

        public void MapAxi(List<double> XAxisValues, List<double>YAxisValues)
        {
            XAxis.AddRange(XAxisValues);
            YAxis.AddRange(YAxisValues);
        }


        public void CreateMapFromString(string input)
        {
            input = input.Replace("\r\n", "\n").Trim().Replace("    ", "\t");

            string[] collumns = input.Split("\n");
            CollumnsCount = collumns.Length;

            for (int x = 0; x < collumns.Length; x++) 
            {
                if (collumns.Length != CollumnsCount)
                    throw new InvalidDataException("MAP NOT SQUARE!");

                string[] rows = collumns[x].Split("\t");
                RowsCount = rows.Length;

                for (int y = 0; y < rows.Length; y++)
                {
                    if (rows.Length != RowsCount)
                        throw new InvalidDataException("MAP NOT SQUARE!");

                    string stringValue = rows[y].Trim();

                    if (double.TryParse(stringValue, out double doubleValue))
                    {
                        Points.Add(new Point(y, x, doubleValue));
                    }
                }
            }
        }
    }
}
