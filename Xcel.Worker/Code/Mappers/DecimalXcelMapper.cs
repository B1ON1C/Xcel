using NPOI.SS.UserModel;
using Xcel.Worker.Code.Iface;

namespace Xcel.Worker.Code.Mappers
{
    internal class DecimalXcelMapper : IXcelDataMapper
    {
        Type IXcelDataMapper.MapperType => typeof(decimal);

        object IXcelDataMapper.Map(ICell cell)
        {
            return (decimal)cell.NumericCellValue;
        }
    }
}
