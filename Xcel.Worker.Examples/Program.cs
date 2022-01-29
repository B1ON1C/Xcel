using System.Reflection;
using Xcel.Worker.Code.Iface;
using Xcel.Worker.Code.Impl;
using Xcel.Worker.Examples.Entities;
using Xcel.Worker.Examples.Mappers;

public static class Program
{
    public static void Main(string[] args)
    {
        // Load excel file
        var excelExample = Assembly.GetExecutingAssembly().GetManifestResourceStream("Xcel.Worker.Examples.Examples.ExcelExample.xlsx");

        // Generate Xcel reader
        IXcelReader<ExcelExample> xcelReader = new XcelReader<ExcelExample>(new List<IXcelDataMapper> { new XcelDataMapper() });

        // Backup data from excel to "excelExampleEntity(ExcelExample)"
        var excelExampleEntity = xcelReader.Read(StreamToByteArray(excelExample), 0);
    }

    private static byte[] StreamToByteArray(Stream stream)
    {
        MemoryStream ms = new();
        stream.CopyTo(ms);
        return ms.ToArray();
    }
}