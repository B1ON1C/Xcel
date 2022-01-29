using Xcel.Worker.Code.Attrib;

namespace Xcel.Worker.Examples.Entities
{
    internal class ExcelExample
    {
        // Employee
        [XcelCoords("C7")]
        public string? EmployeeName { get; set; }

        [XcelCoords("C8")]
        public string? Surname1 { get; set; }

        [XcelCoords("C9")]
        public string? Surname2 { get; set; }

        [XcelCoords("C10")]
        public int? YearsOld { get; set; }

        [XcelCoords("C11")]
        public DateTime? Birthday { get; set; }

        [XcelCoords("C12")]
        public int? FavouriteNumber { get; set; }


        // Company
        [XcelCoords(6, 5)]
        public string? CompanyName { get; set; }

        [XcelCoords(7, 5)]
        public DateTime? CreationDate { get; set; }

        // XcelTest Example
        [XcelCoords("B1")]
        public XcelData? XcelData { get; set; }
    }
}
