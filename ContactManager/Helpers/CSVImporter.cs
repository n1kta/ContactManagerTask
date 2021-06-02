using System;
using System.Collections.Generic;
using System.IO;
using ContactManager.MSSQL.Models;
using Microsoft.AspNetCore.Http;

namespace ContactManager.Helpers
{
    public static class CSVImporter
    {
        private const string CSV_EXTENSION = ".csv";
        private const string INCORRECT_CSV_EXTENSION = "Incorrect file extension.";
        private const string separator = ";";

        public static IEnumerable<Manager> Decoder(IFormFile uploadedFile)
        {
            var result = new List<Manager>();

            if (!uploadedFile.FileName.EndsWith(CSV_EXTENSION))
                throw new Exception(INCORRECT_CSV_EXTENSION);

            using (var reader = new StreamReader(uploadedFile.OpenReadStream()))
            {
                while (!reader.EndOfStream)
                {
                    var rows = reader.ReadLine()?.Split(separator);

                    if (rows != null)
                    {
                        var name = rows[0];
                        var date = DateTime.TryParse(rows[1], out var d) ? d : DateTime.Now;
                        var married = Boolean.TryParse(rows[2], out var m) && m;
                        var phone = rows[3];
                        var salary = Decimal.TryParse(rows[4], out var s) ? s : Decimal.Zero;

                        var manager = new Manager
                        {
                            Name = name,
                            DateOfBirth = date,
                            Married = married,
                            Phone = phone,
                            Salary = salary
                        };

                        result.Add(manager);
                    }
                }
            }

            return result;
        }
    }
}
