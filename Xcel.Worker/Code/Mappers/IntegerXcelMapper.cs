using NPOI.SS.UserModel;
using Xcel.Worker.Code.Iface;

namespace Xcel.Worker.Code.Mappers
{
    internal class IntegerXcelMapper : IXcelDataMapper
    {
        Type IXcelDataMapper.MapperType => typeof(int);

        object IXcelDataMapper.Map(ICell cell)
        {
            return (int)cell.NumericCellValue;
        }
    }
}
