using MVC_NCDAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MVC_NCDAssignment.Misc
{
    static class EmailUtils
    {
        const int MAX_FILES_CAN_ATTACH = 10;
        public static void SendPDFEmail(string email, SearchInfoModel searchModel, List<string> pdfFileNames)
        {
            Queue<string> filesToAttach = new Queue<string>(pdfFileNames);
            while (filesToAttach.Count > 0)
            {
                var mailMessage = new MailMessage();
                mailMessage.To.Add(email);
                mailMessage.Subject = "Search Results";
                StringBuilder bodyBuilder = new StringBuilder();// bodyBuilder, oh yea..
                bodyBuilder.Append("Please check the attached files for the list<br/><br/><u>Search Info Used</u><br/>");

                if (!TextUtils.IsStringEmpty(searchModel.Name))
                    bodyBuilder.Append(string.Format(@"Name : Containing ""{0}""<br/>", searchModel.Name));

              

                if (searchModel.MinAge!= null && searchModel.MaxAge!= null)
                    bodyBuilder.Append(string.Format("Age : From {0} to {1} years <br/>", searchModel.MinAge, searchModel.MaxAge));
                else if (searchModel.MinAge != null)
                    bodyBuilder.Append(string.Format("Age : Min {0} years <br/>", searchModel.MinAge));
                else if (searchModel.MaxAge != null)
                    bodyBuilder.Append(string.Format("Age : Max {0} years <br/>", searchModel.MaxAge));


                if (searchModel.CanBeMale && searchModel.CanBeFemale)
                    bodyBuilder.Append("Sex : Both Males and Females<br/>");
                else if (searchModel.CanBeMale)
                    bodyBuilder.Append("Sex : Males only<br/>");
                else if (searchModel.CanBeFemale)
                    bodyBuilder.Append("Sex : Females only<br/>");


                if (searchModel.MinHeight != null && searchModel.MaxHeight != null)
                    bodyBuilder.Append(string.Format("Height : From {0} to {1} cms <br/>", searchModel.MinHeight, searchModel.MaxHeight));
                else if (searchModel.MinHeight != null)
                    bodyBuilder.Append(string.Format("Height : Min {0} cms <br/>", searchModel.MinHeight));
                else if (searchModel.MaxHeight != null)
                    bodyBuilder.Append(string.Format("Height : Max {0} cms <br/>", searchModel.MaxHeight));



                if (searchModel.MinWeight != null && searchModel.MaxWeight != null)
                    bodyBuilder.Append(string.Format("Weight : From {0} to {1} kgs <br/>", searchModel.MinWeight, searchModel.MaxWeight));
                else if (searchModel.MinWeight != null)
                    bodyBuilder.Append(string.Format("Weight : Min {0} kgs <br/>", searchModel.MinWeight));
                else if (searchModel.MaxWeight != null)
                    bodyBuilder.Append(string.Format("Weight : Max {0} kgs <br/>", searchModel.MaxWeight));


               
                if (!TextUtils.IsStringEmpty(searchModel.Nationality))
                    bodyBuilder.Append(string.Format(@"Nationality : Equals to ""{0}""<br/>", searchModel.Nationality));

                mailMessage.Body = bodyBuilder.ToString();
                mailMessage.IsBodyHtml = true;

                int filesAttached = 0;
                for (; filesAttached < MAX_FILES_CAN_ATTACH; filesAttached++)
                {
                    if (filesToAttach.Count == 0) break;
                    string pdfPath = CriminalUtils.MapFileName(filesToAttach.Dequeue());
                    mailMessage.Attachments.Add(new Attachment(pdfPath));
                }
                try
                {
                    var smtpClient = new SmtpClient();
                    smtpClient.Send(mailMessage);
                }
                catch (Exception)
                {
                    //log this exception, no way to show user now, it is too late as this is running on a background thread.
                }
            }
        }
    }
}
