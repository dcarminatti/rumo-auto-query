using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumoAutoQuery.utils
{
    internal class ExcelHelper
    {
        private readonly string _file;
        public ExcelHelper(string file)
        {
            this._file = file;
        }

        public List<string> ExtractColumn(string columnName)
        {
            List<String> columnValues = new List<string>();
            using (var stream = File.Open(this._file, FileMode.Open, FileAccess.Read))
            { 
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    int columnIndex = this.GetColumnIndex(columnName, reader);


                    while (reader.Read())
                    {
                        string value = reader.GetString(columnIndex);
                        if (value != null || value != "")
                        {
                            columnValues.Add(value);
                        }
                    }
                }
            }
            return columnValues;
        }

        private int GetColumnIndex(string columnName, IExcelDataReader reader)
        {
            reader.Read();
            int count = reader.FieldCount;
            
            for(int i = 0; i < count; i++)
            {
                if (reader.GetString(i).IndexOf(columnName, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return i;
                }
            }

            throw new Exception($"Coluna com o nome '{columnName}'");
        }
    }
}
