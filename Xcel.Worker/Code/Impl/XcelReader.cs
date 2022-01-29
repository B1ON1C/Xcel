using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Reflection;
using Xcel.Worker.Code.Attrib;
using Xcel.Worker.Code.Iface;
using Xcel.Worker.Code.Mappers;
using Xcel.Worker.Code.Utils;

namespace Xcel.Worker.Code.Impl
{
    public class XcelReader<T> : IXcelReader<T> where T : class, new()
    {
        private IList<IXcelDataMapper> Mappers { get; }

        public XcelReader()
        {
            Mappers = new List<IXcelDataMapper>();
            RegisterDefaultMappers();
        }

        public XcelReader(IList<IXcelDataMapper> newMappers)
        {
            Mappers = new List<IXcelDataMapper>();
            RegisterDefaultMappers();
            AddMappers(newMappers);
        }

        T IXcelReader<T>.Read(byte[] document, int sheet)
        {
            var excelSheet = GetSheetFromWorkbook(document, sheet);
            var instanceFromT = GenerateNewInstanceFromT();
            var actionableProperties = GetActionableProperties(instanceFromT);

            return ProcessActionableProperties(instanceFromT, excelSheet, actionableProperties);
        }

        private ISheet GetSheetFromWorkbook(byte[] document, int sheet)
        {
            XSSFWorkbook hssfwb;
            using (MemoryStream file = new MemoryStream(document, 0, document.Length))
            {
                hssfwb = new XSSFWorkbook(file);
            }
            return hssfwb.GetSheetAt(sheet);
        }

        private T GenerateNewInstanceFromT()
        {
            return new T();
        }

        private List<PropertyInfo> GetActionableProperties(T instance)
        {
            return instance
                .GetType()
                .GetProperties()
                .Where(property => property.GetSetMethod() != null)
                .Where(property => Attribute.GetCustomAttribute(property, typeof(XcelCoords)) != null)
                .ToList();
        }

        private T ProcessActionableProperties(T instanceFromT, ISheet excelSheet, List<PropertyInfo> actionableProperties)
        {
            actionableProperties.ForEach(property =>
            {
                var PropertyBaseType = TypeUtils.GetBaseType(property);
                var attribute = Attribute.GetCustomAttribute(property, typeof(XcelCoords)) ?? throw new ArgumentException("Can't load XcelCoords attribute from property");
                var cell = excelSheet.GetRow(((XcelCoords)attribute).Row).GetCell(((XcelCoords)attribute).Col);

                MapValueToProperty(property, PropertyBaseType, instanceFromT, cell);
            });

            return instanceFromT;
        }

        private void MapValueToProperty(PropertyInfo property, Type type, T instance, ICell cell)
        {
            if (cell is null || cell.CellType == CellType.Blank)
                return;

            var mapper = Mappers.Where(mapper => mapper.MapperType == type).FirstOrDefault() ?? throw new Exception("Can't map property. Not found mapper for map the property type");
            property.SetValue(instance, mapper.Map(cell));
        }

        private void RegisterDefaultMappers()
        {
            Mappers.Add(new StringXcelMapper());
            Mappers.Add(new CharXcelMapper());
            Mappers.Add(new IntegerXcelMapper());
            Mappers.Add(new DoubleXcelMapper());
            Mappers.Add(new DecimalXcelMapper());
            Mappers.Add(new BooleanXcelMapper());
            Mappers.Add(new DateTimeXcelMapper());
        }

        private void AddMappers(IList<IXcelDataMapper> newMappers)
        {
            newMappers.ToList().ForEach(newMapper =>
            {
                if (Mappers.FirstOrDefault(existingMapper => newMapper.MapperType == existingMapper.MapperType) != null)
                    throw new ArgumentException("Can't add duplicated mappers type");

                Mappers.Add(newMapper);
            });
        }
    }
}
