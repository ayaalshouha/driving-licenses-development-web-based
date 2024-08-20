using System.Data.Common;
using System.Diagnostics;

namespace DataLayer
{
    public class DataSettings
    {
        public static readonly string ConnectionString = "server=.;database=DVLD_Database;user id=sa;password=sa123456;TrustServerCertificate=True;";

        //public static void StoreUsingEventLogs(string message)
        //{
        //    string sourceName = "DVLD_API_App";

        //    if (!EventLog.SourceExists(sourceName))
        //        EventLog.CreateEventSource(sourceName, "Application");

        //    EventLog.WriteEntry(sourceName, message, EventLogEntryType.Error);
        //}
    }
}
