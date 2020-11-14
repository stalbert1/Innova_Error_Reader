using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innova_Error_Reader.Classes
{
    class ErrorParser
    {

        //This class will be used in a way where 1 static method will be defined where a CSV file is passed in and a List<ErrorCode> will be returned.

        public static List<ErrorCode> getList(string CSVFileNamePath)
        {
            //This syntax is from the .ilinq class.
            //the .skip is passing the first line as this is a header
            //This is creating a list of errorCode objects.
            return File.ReadAllLines(CSVFileNamePath)
                .Skip(1)
                .Where(row => row.Length > 0)
                .Select(ParseRow).ToList();

            
        }

        private static ErrorCode ParseRow(string row)
        {
            var columns = row.Split(',');

            //The columns here is the key columns[0] thru [14] or so is the individual data

            //quick and easy way would be to make sure the column at ? DO, WR or IH DO if it is the wacky one in the UPS can change up the order?

            //place a break point at the return new Error code to see what is going on.

            //Assigining each row to a property of a new error and returning.
            return new ErrorCode(columns[0], columns[1], columns[2], columns[3], columns[4], columns[5], columns[6], columns[7], columns[8], columns[9], columns[11], columns.Count());
        }
    }
}
