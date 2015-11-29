using MVC_NCDAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MVC_NCDAssignment.Misc
{
    public static class SearchUtils
    {
        public const int MAX_NAME_LENGTH = 50;
        public const int MAX_NATIONALITY_LENGTH = 50;
        public const int MIN_AGE = 16;

        internal static void Validate(SearchInfoModel searchModel)
        {
            if (searchModel.MinAge > searchModel.MaxAge)
                throw new Exception("Min age cannot be bigger than max age");

            if (searchModel.MinHeight > searchModel.MaxHeight)
                throw new Exception("Min height cannot be bigger than max height");

            if (searchModel.MinWeight > searchModel.MaxWeight)
                throw new Exception("Min weight cannot be bigger than max weight");

            if (!searchModel.CanBeFemale && !searchModel.CanBeMale)
                throw new Exception("Please select at least one gender");

            if (TextUtils.IsStringEmpty(searchModel.Name) && TextUtils.IsStringEmpty(searchModel.Nationality) &&
                searchModel.MinAge == null && searchModel.MaxAge == null &&
                searchModel.MinHeight == null && searchModel.MaxHeight == null &&
                searchModel.MinWeight == null && searchModel.MaxWeight == null)
                throw new Exception("Please write any one parameter to search");

            if (!string.IsNullOrEmpty(searchModel.Name) && searchModel.Name.Length > MAX_NAME_LENGTH)//for service
                throw new Exception(string.Format("Name can not be bigger than {0} characters", MAX_NAME_LENGTH));

            if (!string.IsNullOrEmpty(searchModel.Nationality) && searchModel.Nationality.Length > MAX_NATIONALITY_LENGTH)//for service
                throw new Exception(string.Format("Nationality can not be bigger than {0} characters", MAX_NATIONALITY_LENGTH));

            if (searchModel.MinAge != null && searchModel.MinAge < MIN_AGE)
                throw new Exception(string.Format("Min age must be bigger than {0}", MIN_AGE));
        }
       


        internal static void InitiateSearch(string email, SearchInfoModel searchModel)
        {
            Validate(searchModel);

            ThreadPool.QueueUserWorkItem(new WaitCallback((object state) => ProcessSearch(email, searchModel)));
        }

        static void ProcessSearch(string email, SearchInfoModel searchModel)
        {
            CriminalsDataContext dc = new CriminalsDataContext();
            byte maleByte = (byte)CriminalInfo.SexType.Male;
            byte femaleByte = (byte)CriminalInfo.SexType.Female;
            var query =
                from a in dc.Criminals
                where (string.IsNullOrEmpty(searchModel.Name) || a.Name.Contains(searchModel.Name))
                where (string.IsNullOrEmpty(searchModel.Nationality) || a.Nationality.Equals(searchModel.Nationality, StringComparison.OrdinalIgnoreCase))
                where (searchModel.MinAge == null || a.Age >= searchModel.MinAge)
                where (searchModel.MaxAge == null || a.Age <= searchModel.MaxAge)
                where (searchModel.MinHeight == null || a.Height >= searchModel.MinHeight)
                where (searchModel.MaxHeight == null || a.Height <= searchModel.MaxHeight)
                where (searchModel.MinWeight == null || a.Weight >= searchModel.MinWeight)
                where (searchModel.MaxWeight == null || a.Weight <= searchModel.MaxWeight)
                where ((searchModel.CanBeMale && searchModel.CanBeFemale) || (searchModel.CanBeMale && a.Sex == maleByte)|| (searchModel.CanBeFemale && a.Sex == femaleByte))
                select a;

            var criminalsList = query.ToList();
            var pdfNamesList = new List<string>(criminalsList.Count);
            foreach (var criminal in criminalsList)
            {
                CriminalInfo ci = new CriminalInfo();
                ci.ID = criminal.Id;
                ci.Name = criminal.Name;
                ci.Age = criminal.Age;
                ci.Sex = (CriminalInfo.SexType)criminal.Sex;
                ci.Height = criminal.Height;
                ci.Weight = criminal.Weight;
                ci.Nationality = criminal.Nationality;
                ci.GeneratePDF();
                pdfNamesList.Add(ci.GetPdfName());
            }

            EmailUtils.SendPDFEmail(email, searchModel, pdfNamesList);
        }

    }
}

