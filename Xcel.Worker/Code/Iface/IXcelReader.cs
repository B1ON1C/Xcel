namespace Xcel.Worker.Code.Iface
{
    public interface IXcelReader<T> where T : class
    {
        public T Read(byte[] document, int sheet);
    }
}
