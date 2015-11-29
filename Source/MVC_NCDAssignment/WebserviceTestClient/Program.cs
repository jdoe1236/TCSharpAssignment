using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebserviceTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var searchServiceClient = new SearchService.SearchServiceClient();
            Console.Write("Sending search request...");
            try
            {
                string emailAddressForResult = "UPDATE@EMAIL.COM";//must be registered account on website

                string name = "some";//contains
                string nationality = null;
                byte? minAge = 20;
                byte? maxAge = null;
                short? minHeight = null;
                short? maxHeight = null;
                short? minWeight = null;
                short? maxWeight = null;
                bool canBeMale = true;
                bool canBeFemale = false;

                if (searchServiceClient.Search(emailAddressForResult, name, minAge, maxAge, canBeFemale, canBeMale, minHeight, maxHeight, minWeight, maxWeight, nationality))
                    Console.Write("Succeed");
                else
                    Console.Write("Failed");
            }
            catch (Exception e)
            {
                Console.Write("Error");
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                searchServiceClient.Close();
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Press 'Enter' key to close the app.");
            Console.ReadLine();
        }
    }
}
