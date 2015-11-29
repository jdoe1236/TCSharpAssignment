using MVC_NCDAssignment.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.Security;

namespace MVC_NCDAssignment
{
    public class SearchService : ISearchService
    {

        public bool Search(string userEmail, string name, byte? minAge, byte? maxAge, bool canBeFemale, bool canBeMale, short? minHeight, short? maxHeight, short? minWeight, short? maxWeight, string nationality)
        {
            try
            {
                //only works if user is logged in, need better way to confirm the user existense
                //   if (Membership.GetUser(userEmail) == null)// for more security, force caller to provide password as param
                //  return false;

                //InitiateSearch does Validation first, so if it failes, it will throw expception
                SearchUtils.InitiateSearch(userEmail, new Models.SearchInfoModel() { Name = name, MinAge = minAge, MaxAge = maxAge, CanBeFemale = canBeFemale, CanBeMale = canBeMale, MinHeight = minHeight, MaxHeight = maxHeight, MinWeight = minWeight, MaxWeight = maxWeight, Nationality = nationality });
                return true;
            }
            catch (Exception)
            {
                //bad idea, should send caller a message about what happened, like in validation, where is the problem.
                //but as in assignment, it must return true or false. Can't change the basic requirement. Or Can I ? *Suspense music plays*
                return false;
            }
        }
    }
}
