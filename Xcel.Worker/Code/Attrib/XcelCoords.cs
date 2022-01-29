using NPOI.SS.Util;

namespace Xcel.Worker.Code.Attrib
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class XcelCoords : Attribute
    {
        public int Row { get; }
        public int Col { get; }
        public XcelCoords(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public XcelCoords(string coords)
        {
            var cellReference = new CellReference(coords);
            {
                Row = cellReference.Row;
                Col = cellReference.Col;
            }
        }
    }
}
