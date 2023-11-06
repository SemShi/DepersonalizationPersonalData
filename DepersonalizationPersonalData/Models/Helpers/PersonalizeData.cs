﻿using System.ComponentModel;
using System.Reflection;

namespace DepersonalizationPersonalData.Models.Helpers
{
    public class PersonalizeData
    {
        public PersonalizeData() { }
        public PersonalizeData(PersonalizeDataFirstTbl firstTbl)
        {
            Data_id = firstTbl.Data_id;
            FirstName = firstTbl.FirstName;
            MiddleName = firstTbl.MiddleName;
            LastName = firstTbl.LastName;
            Birthday = firstTbl.Birthday;
        }
        public PersonalizeData
        (
            PersonalizeDataFirstTbl firstTbl, 
            PersonalizeDataSecondTbl secondTbl,
            PersonalizeDataThirdTbl thirdTbl
        )
        {
            Data_id = firstTbl.Data_id;
            FirstName = firstTbl.FirstName;
            MiddleName = firstTbl.MiddleName;
            LastName = firstTbl.LastName;
            Birthday = firstTbl.Birthday;
            Country = secondTbl.Country;
            Area = secondTbl.Area;
            City = secondTbl.City;
            Phone = secondTbl.Phone;
            Street = thirdTbl.Street;
            Home = thirdTbl.Home;
            Building = thirdTbl.Building;
            Flat = thirdTbl.Flat;
        }
        [Browsable(false)]
        public Guid Data_id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Country { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public int Home { get; set; }
        public string Building { get; set; }
        public int Flat { get; set; }

        [Browsable(false)]
        public string BirthDayToDataBaseFormat
        { 
            get
            {
                if (Birthday == DateTime.MinValue) return $"0001-01-01";
                return $"{Birthday.Year}-{Birthday.Month}-{Birthday.Day}";
            } 
        }

        public string GetFieldByName(string fieldName)
        {
            switch (fieldName)
            {
                case "FirstName":
                    return $"'{FirstName}'";
                case "MiddleName":
                    return $"'{MiddleName}'";
                case "LastName":
                    return $"'{LastName}'";
                case "Birthday":
                    return $"'{BirthDayToDataBaseFormat}'";
                case "Country":
                    return $"'{Country}'";
                case "Area":
                    return $"'{Area}'";
                case "City":
                    return $"'{City}'";
                case "Phone":
                    return $"'{Phone}'";
                case "Street":
                    return $"'{Street}'";
                case "Home":
                    return $"{Home}";
                case "Building":
                    return $"'{Building}'";
                case "Flat":
                    return $"{Flat}";
            }
            return "";
        }

        public bool ValidateModel(out string msg)
        {
            msg = "";
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                msg = "Заполните значение \"Имя\"";
                return false;
            }
            if (string.IsNullOrWhiteSpace(LastName))
            {
                msg = "Заполните значение \"Фамилия\"";
                return false;
            }
            if (string.IsNullOrWhiteSpace(MiddleName))
            {
                msg = "Заполните значение \"Отчество\"";
                return false;
            }
            if (BirthDayToDataBaseFormat == "0001-01-01")
            {
                msg = "Заполните значение \"Дата рождения\"";
                return false;
            }
            if (string.IsNullOrWhiteSpace(Country))
            {
                msg = "Заполните значение \"Страна\"";
                return false;
            }
            if (string.IsNullOrWhiteSpace(Area))
            {
                msg = "Заполните значение \"Область\"";
                return false;
            }
            if (string.IsNullOrWhiteSpace(City))
            {
                msg = "Заполните значение \"Город\"";
                return false;
            }
            if (string.IsNullOrWhiteSpace(Phone))
            {
                msg = "Заполните значение \"Телефон\"";
                return false;
            }
            if (string.IsNullOrWhiteSpace(Street))
            {
                msg = "Заполните значение \"Улица\"";
                return false;
            }
            if (Home == 0)
            {
                msg = "Заполните значение \"Дом\"";
                return false;
            }
            if (string.IsNullOrWhiteSpace(Building))
            {
                msg = "Заполните значение \"Корпус\"";
                return false;
            }
            if (Flat == 0)
            {
                msg = "Заполните значение \"Квартира\"";
                return false;
            }

            return true;
        }
    }
}
