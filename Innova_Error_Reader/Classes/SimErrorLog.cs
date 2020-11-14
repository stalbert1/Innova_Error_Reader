using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Innova_Error_Reader.Classes
{
    class SimErrorLog
    {

        public static List<ErrorCode> getList()
        {

            //This is used to demonstrate the basics of classes
            //ErrorCode error1 = new ErrorCode("9/9/2019", "14:27:20:371", "RTA", "410011", "CLEAR", "WR", "FLUORO_UPS(null)",  "XRAppDir", 5);
           // ErrorCode error2 = new ErrorCode("9/9/2019", "14:27:01:045", "RTA", "410011", "CLEAR", "WR", "FLUORO_UPS(null)", "XRAppDir", 5);
            //ErrorCode error3 = new ErrorCode("9/9/2019", "14:26:51:281", "DL", "281004", "CLEAR", "DO", "Unexpected shutdown requested", "ONOFF_MODULE_FAILURE restart status XRSubsysMgrDLImpl.cxx", 5);
            //ErrorCode error4 = new ErrorCode("9/9/2019", "14:26:51:110", "POS", "1050173", "CLEAR", "DO", "Frt_INVALID_CMD(null)", "XRImChainPosFront", 5);
            //ErrorCode error5 = new ErrorCode("9/9/2019", "14:26:51:109", "POS", "1050173", "CLEAR", "DO", "ARCNET INVALID CMD", "Frontal Unknown Command", 5);
            //ErrorCode error6 = new ErrorCode("9/9/2019", "14:26:51:109", "POS", "1050748", "CLEAR", "DO", "Frt_ERR_REPEATABILITY(null)", "XRImChainPosFront", 5);
        

//9 / 9 / 2019    14:26:51:108    POS 1050168  CLEAR DO   Frt_II_BUMP(null) XRImChainPosFront
//9 / 9 / 2019    14:26:51:106    POS 1050148  CLEAR DO   Frt_ERR_MISCELLANEOUS(null) XRImChainPosFront


            List<ErrorCode> errorLog = new List<ErrorCode>();
            //errorLog.Add(error1);
            //errorLog.Add(error2);
            //errorLog.Add(error3);
            //errorLog.Add(error4);
            //errorLog.Add(error5);
            //errorLog.Add(error6);

            return errorLog;
        }
        
    }
}
