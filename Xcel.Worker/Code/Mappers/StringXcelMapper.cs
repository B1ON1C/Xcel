using NPOI.SS.UserModel;
using Xcel.Worker.Code.Iface;

namespace Xcel.Worker.Code.Mappers
{
    internal class StringXcelMapper : IXcelDataMapper
    {
        Type IXcelDataMapper.MapperType => typeof(string);

        object IXcelDataMapper.Map(ICell cell)
        {
            return cell.StringCellValue;
        }
    }
}
