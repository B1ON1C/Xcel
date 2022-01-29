using NPOI.SS.UserModel;

namespace Xcel.Worker.Code.Iface
{
    public interface IXcelDataMapper
    {
        public Type MapperType { get; }
        public object Map(ICell cell);
    }
}
