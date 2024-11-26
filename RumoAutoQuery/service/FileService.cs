using RumoAutoQuery.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumoAutoQuery.services
{
    internal class FileService
    {
        private readonly string _input;
        private readonly string _output;
        private readonly string _columnName;

        private List<string> _files;

        public FileService(string _input, string _output, string columnName)
        {
            this._input = _input;
            this._output = _output;
            this._columnName = columnName;
            this._files = Directory.GetFiles(_input, "*.xls").ToList();
        }

        public List<string> ReadFiles()
        {
            List<string> columnValues = new List<string>();
            foreach (string file in this._files)
            {
                ExcelHelper excelHelper = new ExcelHelper(file);
                columnValues.AddRange(excelHelper.ExtractColumn(this._columnName));
            }
            return columnValues;
        }
    }
}
