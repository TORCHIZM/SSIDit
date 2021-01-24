using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIDit.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableName : Attribute
    {
        public string Name { get; set; }

        public TableName(string columnName)
        {
            this.Name = columnName;
        }
    }
}
