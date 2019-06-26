using System;
using System.Data;
using System.Data.SQLite;

namespace vSongBook
{
   
    public class AppDatabase
    {
        SQLiteConnection SqlConn;
        SQLiteCommand SqlCmd;
        SQLiteDataAdapter SqlAdapter = null;
        DataSet DtSt = null;
        DataTable DtTb = new DataTable();
        SQLiteDataReader SqlReader;
        DataRowCollection DtRowCol;

        public DataTable DT { get => DtTb; set => DtTb = value; }

        public AppDatabase()
        {
            SqlConn = new SQLiteConnection("Data Source=Data\\Songs.db;New=False;Version=3");
            SqlConn.Open();
        }

        public DataRowCollection GetList(string CommandText)
        {
            DtSt = new DataSet();
            SqlAdapter = new SQLiteDataAdapter(CommandText, SqlConn);
            SqlAdapter.Fill(DtSt);
            DtRowCol = DtSt.Tables[0].Rows;
            SQLClose();
            return DtRowCol;
        }

        public SQLiteDataReader GetSingle(string CommandText)
        {
            SqlCmd = new SQLiteCommand(CommandText, SqlConn);
            SqlReader = SqlCmd.ExecuteReader();
            return SqlReader;
        }

        public string TextRendertoDB(string songStr)
        {
            songStr = songStr.Replace("'", "^");
            songStr = songStr.Replace('"', '+');
            return songStr;
        }

        public string SongRendertoDB(string songStr)
        {
            songStr = songStr.Replace("\r\n\r\n", "|");
            songStr = songStr.Replace("\r\n", "$");
            songStr = songStr.Replace("  ", " ");
            songStr = songStr.Replace("'", "^");
            songStr = songStr.Replace("`", "^");
            songStr = songStr.Replace('"', '+');
            return songStr;
        }

        public string QuickUpdate(string table, string column, string value, string columnid, string columnvl)
        {
            string result = "";
            try
            {
                SqlCmd = new SQLiteCommand("UPDATE " + table + " SET " + column + "=" + value + ", updated='" + Todate() +
                    "' WHERE " + columnid + "= " + columnvl, SqlConn);
                SqlCmd.ExecuteNonQuery();
                result = "success";
            }
            catch (Exception sqlex)
            {
                result = sqlex.ToString();
            }
            return result;
        }

        public string NewSong(string book, string number, string title, string content, string key, string notes, string author)
        {
            string result = "";
            try
            {
                SqlCmd = new SQLiteCommand("INSERT INTO songs " + "(book, number, title, content, key, notes, author, created) VALUES('" +
                book + "', '" + number + "', '" + TextRendertoDB(title) + "', '" + SongRendertoDB(content) + "', '" + key + "', '" + 
                    notes + "', '" + author + "', '" + Todate() + "')", SqlConn);
                SqlCmd.ExecuteNonQuery();
                string songs = ColumnCount("songs", "book", book);
                QuickUpdate("books", "songs", songs, "code", book);
                result = "success";
            }
            catch (Exception sqlex)
            {
                result = sqlex.ToString();
            }
            return result;
        }
         
        public string EditSong(int songid, string book, string number, string title, string content, string key, string notes, string author)
        {
            string result = "";
            try
            {
                SqlCmd = new SQLiteCommand("UPDATE songs SET book='" + book + "', number='" +
                    number + "', title='" + title + "', content='" + content + "', key='" + key + 
                    "', notes='" + notes + "', author='" + author + "', updated='" + Todate() + 
                    "' WHERE songid=" + songid, SqlConn);
                SqlCmd.ExecuteNonQuery();
                result = "success";
            }
            catch (Exception sqlex)
            {
                result = sqlex.ToString();
            }
            return result;
        }

        public string ColumnCount(string table, string column, string value)
        {
            string result = "";
            try
            {
                SqlCmd = new SQLiteCommand("SELECT COUNT(*) FROM " + table + " WHERE " + column + "= '" + value + "';", SqlConn);
                SqlCmd.CommandType = CommandType.Text;
                result = (SqlCmd.ExecuteScalar()).ToString();
            }
            catch (Exception sqlex)
            {
                result = sqlex.ToString();
            }
            return result;
        }

        public string AddNewBook(string title, string code, string content)
        {
            string result = "";
            try
            {
                int songs = Convert.ToInt32(ColumnCount("songs", "book", code));
                SqlCmd = new SQLiteCommand("INSERT INTO books (title, code, content, songs, created) VALUES('" + title + "', '" + code + "', '" + 
                    content + "', '" + songs + "', '" + Todate() + "')", SqlConn);
                SqlCmd.ExecuteNonQuery();
                result = "success";
            }
            catch (Exception sqlex)
            {
                result = sqlex.ToString();
            }
            return result;
        }
       
        public string EditBook(string bookid, string title, string code, string content)
        {
            string result = "";
            try
            {
                int songs = Convert.ToInt32(ColumnCount("songs", "book", code));
                SqlCmd = new SQLiteCommand("UPDATE books SET title='" + title + "', code='" + code + "', content='" + content + 
                    "', songs=" + songs + ", updated='" + Todate() + "' WHERE bookid=" + bookid, SqlConn);
                SqlCmd.ExecuteNonQuery();
                result = "success";
            }
            catch (Exception sqlex)
            {
                result = sqlex.ToString();
            }
            return result;
        }
        
        public void SongsUpdate(string code, int songs)
        {
            try
            {
                SqlCmd = new SQLiteCommand("UPDATE books SET songs='" + songs.ToString() + "', updated='" +
                    Todate() + "' WHERE code=" + code, SqlConn);
                SqlCmd.ExecuteNonQuery();
            }
            catch (Exception) { }
        }

        public string Todate()
        {
            return DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
        }

        public void SQLClose()
        {
            //SqlConn.Close();
        }

    }
}
