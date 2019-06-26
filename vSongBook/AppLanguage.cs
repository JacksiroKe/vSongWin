using System;
using System.Data;
using System.Diagnostics;
using System.Data.SQLite;

namespace vSongBook
{
    class AppLanguage
    {
        SQLiteConnection SqlConn;
        SQLiteCommand SqlCmd;
        SQLiteDataReader SqlReader;

        public AppLanguage()
        {
            try
            {
                // Get the settings for this application.
                SqlConn = new SQLiteConnection("Data Source=Data\\Language.db;New=False;Version=3");
                SqlConn.Open();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception while using IsolatedStorageSettings: " + e.ToString());
            }
        }
        public DataRowCollection langList()
        {
            DataSet DtSt = new DataSet();
            string connString = String.Format("Data Source={0};New=False;Version=3", "Data\\Language.db");
            SQLiteConnection SqlConn = new SQLiteConnection(connString);
            //SqlConn.Open();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("SELECT name FROM sqlite_master WHERE type='table';", SqlConn);
            dataAdapter.Fill(DtSt);
            DataRowCollection dataRowCol = DtSt.Tables[0].Rows;            
            //SqlConn.Close();
            return dataRowCol;
        }
        public bool setCheck(string Language, string Key)
        {
            bool keyexists = false;
            //SqlConn.Open();
            SqlCmd = new SQLiteCommand("SELECT stringid FROM " + Language + " WHERE title='" + Key + "' LIMIT 1", SqlConn);
            SqlReader = SqlCmd.ExecuteReader();
            if (SqlReader.Read()) keyexists = true;
            //SqlConn.Close();
            return keyexists;
        }

        /// <summary>
        /// Get a setting value for our application.
        /// </summary>
        public string getValue(string Language, string Key)
        {
            string settvalue = "";
            //SqlConn.Open();
            SqlCmd = new SQLiteCommand("SELECT content FROM " + Language + " WHERE title='" + Key + "' LIMIT 1", SqlConn);
            SqlReader = SqlCmd.ExecuteReader();
            while (SqlReader.Read())
            {
                settvalue = SqlReader["content"].ToString();
            }
            //SqlConn.Close();
            return settvalue;
        }

        /// <summary>
        /// Update a setting value for our application. 
        /// </summary>
        public void setValue(string Language, string Key, string Value)
        {
            //SqlConn.Open();
            string SqlString = "UPDATE " + Language + " SET content='" + Value + "', updated='" + Todate() + "' WHERE title='" + Key + "'";
            SqlCmd = new SQLiteCommand(SqlString, SqlConn);
            SqlCmd.ExecuteNonQuery();
            //SqlConn.Close();
        }

        /// <summary>
        /// Update a setting value for our application. 
        /// </summary>
        public void setNew(string Language, string Key, string Value)
        {
            //SqlConn.Open();
            SqlCmd = new SQLiteCommand("INSERT INTO " + Language + " (title, content, created) VALUES('" +
                Key + "', '" + Value + "', '" + Todate() + "')", SqlConn);
            SqlCmd.ExecuteNonQuery();
            //SqlConn.Close();
        }

        public string Todate()
        {
            return DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
        }
        /// <summary>
        /// Date that vSongBook got installed on this PC
        /// </summary>
        public string As_Lang(string Language, string Key)
        {
            string value;

            // If the key exists, retrieve the value.
            if (setCheck(Language, Key))
            {
                value = getValue(Language, Key);
                if (value.Length == 0) return Key;
                else return value;
            }
            // Otherwise, use the default value.
            else return Key;
        }

        public string As_Lang_Arr(string langstring, string[] valuestrings)
        {
            string finalstring = "";
            string[] langstrings = langstring.Split('#');
            int langslength = langstrings.Length;
            if (langslength > 1)
            {
                for (int i = 0; i < langslength - 1; i++) finalstring = finalstring + langstrings[i] + valuestrings[i];
                if (langstrings[langslength - 1].Length > 1) finalstring = finalstring + langstrings[langslength - 1];
            }
            else
            {
                for (int k = 0; k < valuestrings.Length; k++) finalstring = finalstring + " " + valuestrings[k];
                finalstring = finalstring + langstring;
            }
            return finalstring;
        }
    }
}
