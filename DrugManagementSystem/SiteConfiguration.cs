using System;
namespace DrugManagementSystem
{
    public class SiteConfiguration
    {
        public SiteConfiguration()
        {
        }

        public class ConnectionStringsOptions
        {
            public const string ConnectionStrings = "ConnectionStrings";

            public string DrugsConnectionStr { get; set; }
        }
    }
}
