using CsvHelper;
using Faker;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June12Homework.Data
{
    public static class StaticPersonsClass
    {
        public static List<Person> Generate(int amount)
        {
            List<Person> ppl = new();
            for (int i = 1; i <= amount; i++)
            {
                ppl.Add(new()
                {
                    FirstName = Faker.Name.First(),
                    LastName = Faker.Name.Last(),
                    Age = Faker.RandomNumber.Next(20, 100),
                    Address = Faker.Address.StreetAddress(),
                    Email = Faker.Internet.Email()
                });
            }
            return ppl;
        }

        public static List<Person> GetCsvFromBytes(byte[] csvBytes)
        {
            using var memoryStream = new MemoryStream(csvBytes);
            var streamReader = new StreamReader(memoryStream);
            using var reader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            return reader.GetRecords<Person>().ToList();
        }

        public static string BuildPeopleCsv(List<Person> people)
        {
            var builder = new StringBuilder();
            var stringWriter = new StringWriter(builder);
            using var csv = new CsvWriter(stringWriter, CultureInfo.InvariantCulture);
            csv.WriteRecords(people);
            return builder.ToString();
        }
    }
}
