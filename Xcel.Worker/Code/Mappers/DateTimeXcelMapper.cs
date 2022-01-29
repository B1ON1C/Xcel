using NPOI.SS.UserModel;
using Xcel.Worker.Code.Iface;

namespace Xcel.Worker.Code.Mappers
{
    internal class DateTimeXcelMapper : IXcelDataMapper
    {
        Type IXcelDataMapper.MapperType => typeof(DateTime);

        object IXcelDataMapper.Map(ICell cell)
        {
            return cell.DateCellValue;
        }
    }
}
