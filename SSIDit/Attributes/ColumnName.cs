using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIDit.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnName : Attribute
    {
        public string Name { get; set; }

        public ColumnName(string columnName)
        {
            this.Name = columnName;
        }
    }
}
