using NPOI.SS.UserModel;
using Xcel.Worker.Code.Iface;

namespace Xcel.Worker.Code.Mappers
{
    internal class BooleanXcelMapper : IXcelDataMapper
    {
        Type IXcelDataMapper.MapperType => typeof(bool);

        object IXcelDataMapper.Map(ICell cell)
        {
            return cell.BooleanCellValue;
        }
    }
}
