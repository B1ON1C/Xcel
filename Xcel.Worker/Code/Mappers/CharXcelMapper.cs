using NPOI.SS.UserModel;
using Xcel.Worker.Code.Iface;

namespace Xcel.Worker.Code.Mappers
{
    internal class CharXcelMapper : IXcelDataMapper
    {
        Type IXcelDataMapper.MapperType => typeof(char);

        object IXcelDataMapper.Map(ICell cell)
        {
            return cell.StringCellValue[0];
        }
    }
}
