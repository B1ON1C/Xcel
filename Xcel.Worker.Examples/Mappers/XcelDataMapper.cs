using NPOI.SS.UserModel;
using Xcel.Worker.Code.Iface;
using Xcel.Worker.Examples.Entities;

namespace Xcel.Worker.Examples.Mappers
{
    public class XcelDataMapper : IXcelDataMapper
    {
        Type IXcelDataMapper.MapperType => typeof(XcelData);

        object IXcelDataMapper.Map(ICell cell)
        {
            var cellDataSplit = cell.StringCellValue.Split(";");
            return new XcelData
            {
                Author = cellDataSplit[0] ?? string.Empty,
                Version = cellDataSplit[1] ?? string.Empty,
                Platform = cellDataSplit[2] ?? string.Empty
            };
        }
    }
}
