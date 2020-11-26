using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innova_Error_Reader.Classes
{
    class ErrorCode
    {
        //If you wanted to make it truly public{ get; set; }
        //read only
        public string date { get; } 
        public string time { get; }
        public string subsystem { get; }
        public string errorCode { get; }
        public string errorText { get; }
        public string errorClass { get; }

        //added
        //major, minor
        public string major { get; }
        public string minor { get; }

        public string recomendAction { get; }

        //added
        //9 root cause
        public string rootCause { get; }

        public string debugText { get; }

        //This is used for test purposes to see how many columns are in each error
        public int columns { set; get; }

        public DateTime timeStamp { set; get; }

        //this is the position in the csv file each item should be indexed.
        //var date: String //0
        //var time: String //1

        //should be enum DL, RTA, POS, ???
        //var subsystem: String //2
        //var errorCode: String //3
        //var errorText: String //4

        //should be enum AR, WR, DO ???
        //var errorClass: String //5

        //Will leave these 2 out, for now.
        //6 major function string
        //7 minor function string

        //8 recommended action string
        //var recommendAction: String //8

        //Will leave these 2 out, for now.
        //9 root cause
        //10 times

        //11 debug text
        //var debugText: String //11

        //12 source file

        // These do not get processed correctly, note the , after the double!!
        //2019/09/09,14:27:01:045,RTA,410011,"ALARM (!! , 2.15) - Load on Inverter (OFF)",WR, XRAppDir, control, FLUORO_UPS,0,0, Battery loading,XRPAtlasLogger.cpp,114,

        //Misses key info on this error
        //2019/09/09,14:26:50:847,POS,1050748, ERR REPEATABILITY,DO, PosUserInterface, 0, Frt_ERR_REPEATABILITY,0,0, - Repeatability issue on Plane Index=0xfc0,axis Id=9 name=TBL_LONG,Motion=889 mm or 1/10deg,motionMonitoring.c,550,
        //date      ,time        ,subsystem, error code, err text, err class, major, minor, rec action, root cause, times, debug text

        //constructor
        public ErrorCode(string _date, string _time, string _subsystem, string _errorCode, string _errorText, string _errorClass, string _major, string _minor, string _recomendAction, string _rootCause, string _debugText, int _columns)
        {
            date = _date;
            time = _time;
            subsystem = _subsystem;
            errorCode = _errorCode;
            errorText = _errorText;
            errorClass = _errorClass;

            //added 
            major = _major;
            minor = _minor;

            recomendAction = _recomendAction;

            //added
            rootCause = _rootCause;

            debugText = _debugText;

            //test data
            columns = _columns;

            //Now that we have date and time as a string turn them into a time object and store as a property.
            setDateAndTime();

           

        }

        //This is a test method that will be used to count all columns in all rows and dispense a print statement
        //example...
        //4578 rows had 16 columns, 1678 rows had 17 columns, 345 rows had 19 columns.
        //For now it only outputs the number of the distinct columns.
        //Max columns 15 16 18 20 17 
        
        public static string columnsInRows(List<ErrorCode> errorList)
        {
            List<int> numbers = new List<int>();

            foreach (var error in errorList)
            {
                numbers.Add(error.columns);
            }

            //This will turn the massive List into a list of the distinct int values.
            var uniqueList = numbers.Distinct();

            //Need to start with a base string and will concatenate through the next for loop.
            var returnedString = "Max columns ";

            foreach (var number in uniqueList)
            {
                returnedString = returnedString + $"{number} ";
            }

            return returnedString;

        }
        
        public static string daysInErrorLog(List<ErrorCode> errorList)
        {
            //need to give inital date to each. will prime by using the first one.
            DateTime minDate = errorList[0].timeStamp;
            DateTime maxDate = errorList[0].timeStamp;

            var test = "";

            foreach (var error in errorList)
            {
                if (error.timeStamp < minDate)
                {
                    minDate = error.timeStamp;
                }

                if (error.timeStamp > maxDate)
                {
                    maxDate = error.timeStamp;
                }
                
            }

            var diff = maxDate.Subtract(minDate);

            test = $"{diff.ToString("%d")} days in error list";

            return test;

        }

        private void setDateAndTime()
        {

            //this will shorten the format of the time string so that it can be converted to DateTime object
            var timeStr = time.Remove(8);

            //need to combine the date and the time into one string
            var dateTimeStrg = $"{date} {timeStr}";

            DateTime convDate;

            if (DateTime.TryParse(dateTimeStrg, out convDate))
            {
                timeStamp = convDate;
            }


        }

        //overriding the to string method
        public override string ToString()
        {
            string errorStr = $"Date is {date}. Time is {time}, subsytem that reported issue is {subsystem}. Errorcode is {errorCode} and errortext is {errorText}. Error class is {errorClass}. Action to take is {recomendAction} and the debug text is {debugText}";
            //return base.ToString();
            return errorStr;
        }
    }
}

