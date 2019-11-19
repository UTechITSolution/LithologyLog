using System.Collections;
using System.Collections.Generic;

namespace LithologyLog.Web.Models
{
    public class PageCreationMember
    {
        public float RullerLeftBeginNumber { get; set; }
        public ICollection<Column> Columns { get; set; }
        public ICollection<Column_3> Columns_3 { get; set; }
        public ICollection<Column_4> Columns_4 { get; set; }
        public ICollection<Column_5> Columns_5 { get; set; }
        public ICollection<Column_6> Columns_6 { get; set; }
        public ICollection<Column_7> Columns_7 { get; set; }
        public ICollection<Column_8> Columns_8 { get; set; }
        public ICollection<Column_9> Columns_9 { get; set; }
        public ICollection<Column_10> Columns_10 { get; set; }
        public ICollection<Column_11> Columns_11 { get; set; }
        public ICollection<Column_12> Columns_12 { get; set; }
        public ICollection<Column_13> Columns_13 { get; set; }
    }

    public class ColumnSetting
    {
        public const int HeaderHeight = 153;
        public const int ColumnCount = 13;
        public const int TabelHeight = 1403;
        public const int TabelWidth = 1565;
    }

    public class Column
    {
        public byte Index { get; set; }
        public string MainText { get; set; }
        public string PartTextOne { get; set; }
        public string PartTextTwo { get; set; }
        public string PartTextThree { get; set; }
        public float X { get; set; }
        public float Width { get; set; }
        public float IncreaseSize { get; set; }
        public bool Visible { get; set; }
        public byte Order { get; set; }
    }

    public abstract class ColumnBase
    {
        public float Y { get; set; }
        public string Value { get; set; }
    }

    public class Column_3 : ColumnBase
    {

    }
    public class Column_4 : ColumnBase
    {

    }
    public class Column_5 : ColumnBase
    {

    }
    public class Column_6 : ColumnBase
    {
        public float Y2 { get; set; }
        public string ImageSrc { get; set; }
    }
    public class Column_7 : ColumnBase
    {
        public float Length1 { get; set; }
        public float Length2 { get; set; }
    }
    public class Column_8 : ColumnBase
    {
        public float TextHeight { get; set; }
    }
    public class Column_9 : ColumnBase
    {
        public float Value1 { get; set; }
        public float Value2 { get; set; }
        public float Value3 { get; set; }
    }
    public class Column_10 : ColumnBase
    {

    }
    public class Column_11 : ColumnBase
    {
        public float Y2 { get; set; }
        public byte ColumnType { get; set; }
    }
    public class Column_12 : ColumnBase
    {

    }

    public class Column_13 : ColumnBase
    {
        public float Y2 { get; set; }
        public byte ColumnType { get; set; }
    }

    public enum ColumnType
    {
        PartOne = 1,
        PartTwo = 2,
        PartThree = 3

    }
}
