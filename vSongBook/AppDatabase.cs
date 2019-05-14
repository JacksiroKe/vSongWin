using System;
using System.Data;
using System.Data.SQLite;

namespace vSongBook
{
   
    public class AppDatabase
    {
        SQLiteConnection sConn;
        SQLiteCommand sCmd;
        SQLiteDataAdapter sAdapter = null;
        DataSet dS = null;
        DataTable dT = new DataTable();
        SQLiteDataReader reader;
        DataRowCollection dRowCol;

        public DataTable DT { get => dT; set => dT = value; }

        public AppDatabase()
        {
            sConn = new SQLiteConnection("Data Source=db\\vSongBook.db;New=False;Version=3");
            sConn.Open();
        }

        public DataRowCollection GetList(string CommandText)
        {
            dS = new DataSet();
            sAdapter = new SQLiteDataAdapter(CommandText, sConn);
            sAdapter.Fill(dS);
            dRowCol = dS.Tables[0].Rows;
            SQLClose();
            return dRowCol;
        }

        public SQLiteDataReader GetSingle(string CommandText)
        {
            sCmd = new SQLiteCommand(CommandText, sConn);
            reader = sCmd.ExecuteReader();
            return reader;
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
                sCmd = new SQLiteCommand("UPDATE " + table + " SET " + column + "=" + value + ", updated='" + Todate() +
                    "' WHERE " + columnid + "= " + columnvl, sConn);
                sCmd.ExecuteNonQuery();
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
                sCmd = new SQLiteCommand("INSERT INTO songs " + "(book, number, title, content, key, notes, author, created) VALUES('" +
                book + "', '" + number + "', '" + TextRendertoDB(title) + "', '" + SongRendertoDB(content) + "', '" + key + "', '" + 
                    notes + "', '" + author + "', '" + Todate() + "')", sConn);
                sCmd.ExecuteNonQuery();
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
                sCmd = new SQLiteCommand("UPDATE songs SET book='" + book + "', number='" +
                    number + "', title='" + title + "', content='" + content + "', key='" + key + 
                    "', notes='" + notes + "', author='" + author + "', updated='" + Todate() + 
                    "' WHERE songid=" + songid, sConn);
                sCmd.ExecuteNonQuery();
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
                sCmd = new SQLiteCommand("SELECT COUNT(*) FROM " + table + " WHERE " + column + "= '" + value + "';", sConn);
                sCmd.CommandType = CommandType.Text;
                result = (sCmd.ExecuteScalar()).ToString();
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
                sCmd = new SQLiteCommand("INSERT INTO books (title, code, content, songs, created) VALUES('" + title + "', '" + code + "', '" + 
                    content + "', '" + songs + "', '" + Todate() + "')", sConn);
                sCmd.ExecuteNonQuery();
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
                sCmd = new SQLiteCommand("UPDATE books SET title='" + title + "', code='" + code + "', content='" + content + 
                    "', songs=" + songs + ", updated='" + Todate() + "' WHERE bookid=" + bookid, sConn);
                sCmd.ExecuteNonQuery();
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
                sCmd = new SQLiteCommand("UPDATE books SET songs='" + songs.ToString() + "', updated='" +
                    Todate() + "' WHERE code=" + code, sConn);
                sCmd.ExecuteNonQuery();
            }
            catch (Exception) { }
        }

        public string Todate()
        {
            return DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
        }

        public void SQLClose()
        {
            sConn.Close();
        }

    }
}
