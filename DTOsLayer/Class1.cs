using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer
{
    public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
    public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };
    public enum enMode { add, update }
    public enum enStatus : int { New = 1, cancelled, completed }
    public enum enApplicationType : int
    {
        NewLocalDL = 1, RenewDL = 2, LostReplacement = 3,
        DamagedReplacement = 4, ReleaseDetainedDL = 5, NewInternationalDL = 6, RetakeTest = 7
    }    
    
    
    

}

