using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vSongBook
{
    class AppFunctions
    {

        public AppFunctions()
        {

        }

        public string textRender(string songStr)
        {
            songStr = songStr.Replace("^", "'");
            songStr = songStr.Replace('+', '"');
            return songStr;
        }

        public string songRender(string songStr)
        {
            songStr = songStr.Replace("$", "\r\n");
            songStr = songStr.Replace("|", "\r\n\r\n");
            songStr = songStr.Replace("\r\n ", "\r\n");
            songStr = songStr.Replace("^", "'");
            songStr = songStr.Replace('+', '"');
            return songStr;
        }

        public string timeNow()
        {
            return DateTime.Now.Hour + ":" + DateTime.Now.Minute;
        }
        public string dateToday()
        {
            string weekday = DateTime.Today.DayOfWeek.ToString();
            string dayth = getDaySuf(DateTime.Today.Day);
            string month = getMonSuf(DateTime.Today.Month);
            return weekday + " " + dayth + ", " + month + " " + DateTime.Today.Year;
        }

        public string getDaySuf(int nDay)
        {
            switch (nDay)
            {
                case 1: return nDay + "st";
                case 2: return nDay + "nd";
                case 3: return nDay + "rd";
                case 21: return nDay + "st";
                case 22: return nDay + "nd";
                case 23: return nDay + "rd";
                case 31: return nDay + "st";
                default: return nDay + "th";
            }
        }

        public string getMonSuf(int mon)
        {
            switch (mon)
            {
                case 1: return "Jan";
                case 2: return "Feb";
                case 3: return "Mar";
                case 4: return "Apr";
                case 5: return "May";
                case 6: return "Jun";
                case 7: return "Jul";
                case 8: return "Aug";
                case 9: return "Sep";
                case 10: return "Oct";
                case 11: return "Nov";
                case 12: return "Dec";
                default: return "";
            }
        }

        public int fontNo(string typevalue)
        {
            switch (typevalue)
            {
                case "Arial": return 0;
                case "Calibri": return 1;
                case "Century Gothic": return 2;
                case "Comic Sans MS": return 3;
                case "Corbel": return 4;
                case "Courier New": return 5;
                case "Palatino Linotype": return 6;
                case "Tahoma": return 7;
                case "Tempus Sans ITC": return 8;
                case "Times New Roman": return 9;
                case "Trebuchet MS": return 10;
                case "Verdana": return 11;
                default: return 10;
            }
        }

        public string fonTxt(int typevalue)
        {
            switch (typevalue)
            {
                case 0: return "Arial";
                case 1: return "Calibri";
                case 2: return "Century Gothic";
                case 3: return "Comic Sans MS";
                case 4: return "Corbel";
                case 5: return "Courier New";
                case 6: return "Palatino Linotype";
                case 7: return "Tahoma";
                case 8: return "Tempus Sans ITC";
                case 9: return "Times New Roman";
                case 10: return "Trebuchet MS";
                case 11: return "Verdana";
                default: return "Trebuchet MS";
            }
        }

        public class Language
        {
            public string Code { get; set; }
            public string Phrase { get; set; }
        }

        public void readLangs(string language)
        {
            var strings = new List<Language>();
            //using (var fileStream = new FileStream(language + ".txt"), FileMode.OpenOrCreate, FileAccess.Read))
        }

    }
}
