using MISPISIT_lab_3_4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISPISIT_lab_3_4
{
    internal class FileIOService
    {
        private readonly string _file;

        public FileIOService(string file)
        {
            _file = file;
        }

        public BindingList<Employee> LoadData()
        {
            var fileExists = File.Exists(_file);
            if(!fileExists)
            {
                File.CreateText(_file).Dispose();
                return new BindingList<Employee>();
            }
            using(var reader = File.OpenText(_file))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Employee>>(fileText);
            }
        }

        public void SaveData(object EmployeeData)
        {
            using (StreamWriter writer = File.CreateText(_file))
            {
                string output = JsonConvert.SerializeObject(EmployeeData);
                writer.Write(output);
            }
        }
    }
}
