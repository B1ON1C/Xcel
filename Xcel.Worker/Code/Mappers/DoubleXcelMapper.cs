using NPOI.SS.UserModel;
using Xcel.Worker.Code.Iface;

namespace Xcel.Worker.Code.Mappers
{
    internal class DoubleXcelMapper : IXcelDataMapper
    {
        Type IXcelDataMapper.MapperType => typeof(double);

        object IXcelDataMapper.Map(ICell cell)
        {
            return (double)cell.NumericCellValue;
        }
    }
}
