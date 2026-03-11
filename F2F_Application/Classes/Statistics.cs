using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2F_Application.Classes
{
    class Statistics
    {
        public class Data
        {
            public int TotalFamilyCount { get; set; }
            public int TotalMemberCount { get; set; }
            public int BeneficiariesAverage { get; set; }
            public int YearlyPowerCost { get; set; }
            public int AverageAgeAids { get; set; }
            public int AverageAgePerson { get; set; }
            public int TotalMicroBenef { get; set; }

        }

        public class LivingWithFamilyData
        {
            public int YesCount { get; set; }
            public int NoCount { get; set; }
        }
        public class MemberInsideFamilyData
        {
            public int FamilyCount { get; set; }
            public int MemberCount { get; set; }
        }
        public class FamilyInsideParishData
        {
            public int FamilyCount { get; set; }
            public string ParishName { get; set; }
        }
        public class HasAmperData
        {
            public int YesCount { get; set; }
            public int NoCount { get; set; }
        }
        public class HasSolarPowerData
        {
            public int YesCount { get; set; }
            public int NoCount { get; set; }
        }
        public class HasBatteryData
        {
            public int YesCount { get; set; }
            public int NoCount { get; set; }
        }
        public class HasElectricityData
        {
            public int YesCount { get; set; }
            public int NoCount { get; set; }
        }
        public class HasAmperAidData
        {
            public int YesCount { get; set; }
            public int NoCount { get; set; }
        }
        public class AidsourceAmper
        {
            public int FamilyCount { get; set; }
            public string AidsourceName { get; set; }
        }
        public class AidsourcePower
        {
            public int FamilyCount { get; set; }
            public string AidsourceName { get; set; }
        }
        public class AidnameCount
        {
            public int FamilyCount { get; set; }
            public string AidName { get; set; }
        }
        public class AidSourceCount
        {
            public int FamilyCount { get; set; }
            public string AidSource { get; set; }
        }
        public class PersonGenderData
        {
            public int MaleCount { get; set; }
            public int FemaleCount { get; set; }
        }
        public class PersonStateData
        {
            public int MemberCount { get; set; }
            public string StateName { get; set; }
        }
        public class PersonStateTypeData
        {
            public string StatusName { get; set; }
            public int MemberCount { get; set; }
        }
        public class PersonAgeGenderData
        {
            public string AgerangeName { get; set; }
            public int MaleCount { get; set; }
            public int FemaleCount { get; set; }
        }
        public class PersonWorkData
        {
            public string workingStatus { get; set; }
            public int MaleCount { get; set; }
            public int FemaleCount { get; set; }
        }
        public class PersonWorkPositionData
        {
            public string workingPosition { get; set; }
            public int Count { get; set; }
        }
        public class PersonWorkNameData
        {
            public string WorkName { get; set; }
            public int MemberCount { get; set; }
        }
        public class PersonMPAIDSourceData
        {
            public string AidName { get; set; }
            public int Count { get; set; }
        }
        public class PersonDiseaseCatData
        {
            public string DiseaseType { get; set; }
            public int Count { get; set; }
        }
        public class PersonDiseaseNameData
        {
            public string DiseaseName { get; set; }
            public int MemberCount { get; set; }
        }
        public class PersonDiseaseAidData
        {
            public string AidName { get; set; }
            public int MemberCount { get; set; }
        }
        public class PersonMigrateYearData
        {
            public string Year { get; set; }
            public int MemberCount { get; set; }
        }
        public class PersonMigrateCountryData
        {
            public string CountryName { get; set; }
            public int MemberCount { get; set; }
        }
    }
}
