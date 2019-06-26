using System;
using System.Diagnostics;
using System.Data.SQLite;

namespace vSongBook
{
    class AppSettings
    {
        SQLiteConnection SqlConn;
        SQLiteCommand SqlCmd;
        SQLiteDataReader SqlReader;


        // Database key names of our settings
        const string install_date_Key = "install_date";
        const string app_user_Key = "app_user";
        const string theme_Key = "theme";
        const string language_Key = "language";
        const string show_startpage_Key = "show_startpage";
        const string general_font_size_Key = "general_font_size";
        const string general_font_type_Key = "general_font_type";
        const string general_font_bold_Key = "general_font_bold";
        const string selected_book_Key = "selected_book";
        const string selected_song_Key = "selected_song";
        const string list_font_bold_Key = "list_font_bold";
        const string preview_font_size_Key = "preview_font_size";
        const string preview_font_type_Key = "preview_font_type";
        const string preview_font_bold_Key = "preview_font_bold";
        const string project_font_size_Key = "project_font_size";
        const string project_font_type_Key = "project_font_type";
        const string project_font_bold_Key = "project_font_bold";
        const string edit_mode_Key = "edit_mode";
        const string last_window_startup_Key = "last_window_startup";
        const string last_window_width_Key = "last_window_width";
        const string last_window_height_Key = "last_window_height";
        const string tablet_mode_Key = "tablet_mode";
        const string show_help_first_Key = "show_help_first";
        const string current_song_Key = "current_song";
        const string search_allbooks_Key = "search_allbooks";
        const string vsb_version_Key = "vsb_version";

        // The default value of our settings
        const string install_date_Default = "null";
        const string app_user_Default = "null";
        const string theme_Default = "1";
        const string language_Default = "English";
        const string show_startpage_Default = "1";
        const string general_font_size_Default = "20";
        const string general_font_type_Default = "Trebuchet MS";
        const string general_font_bold_Default = "0";
        const string selected_book_Default = "0";
        const string selected_song_Default = "0";
        const string list_font_bold_Default = "0";
        const string preview_font_size_Default = "11";
        const string preview_font_type_Default = "Trebuchet MS";
        const string preview_font_bold_Default = "0";
        const string project_font_size_Default = "33";
        const string project_font_type_Default = "Trebuchet MS";
        const string project_font_bold_Default = "0";
        const string edit_mode_Default = "1";
        const string last_window_startup_Default = "1";
        const string last_window_width_Default = "14085";
        const string last_window_height_Default = "8655";
        const string tablet_mode_Default = "0";
        const string show_help_first_Default = "1";
        const string current_song_Default = "3";
        const string search_allbooks_Default = "1";
        const string vsb_version_Default = "0.1";

        public AppSettings()
        {
            try
            {
                // Get the settings for this application.
                SqlConn = new SQLiteConnection("Data Source=Data\\Settings.db;New=False;Version=3");
                SqlConn.Open();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception while using IsolatedStorageSettings: " + e.ToString());
            }
        }

        public bool SetBool(string key)
        {
            if (Int32.Parse(key) == 1) return true;
            else return false;
        }

        public string GetBool(bool key)
        {
            if (key == true) return "1";
            else return "0";
        }

        public bool SetCheck(string key)
        {
            bool keyexists = false;
            //SqlConn.Open();
            SqlCmd = new SQLiteCommand("SELECT settingid FROM settings WHERE title='" + key + "' LIMIT 1", SqlConn);
            SqlReader = SqlCmd.ExecuteReader();
            if (SqlReader.Read()) keyexists = true;
            //SqlConn.Close();
            return keyexists;
        }

        /// <summary>
        /// Get a setting value for our application.
        /// </summary>
        public string GetValue(string key)
        {
            string settvalue = "";
            //SqlConn.Open();
            SqlCmd = new SQLiteCommand("SELECT content FROM settings WHERE title='" + key + "' LIMIT 1", SqlConn);
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
        public void SetValue(string Key, string Value)
        {
            //SqlConn.Open();
            string sqlString = "UPDATE settings SET content='" + Value + "', updated='" +
                Todate() + "' WHERE title='" + Key + "'";
            SqlCmd = new SQLiteCommand(sqlString, SqlConn);
            SqlCmd.ExecuteNonQuery();
            //SqlConn.Close();
        }

        /// <summary>
        /// Update a setting value for our application. 
        /// </summary>
        public void SetNew(string Key, Object Value)
        {
            //SqlConn.Open();
            SqlCmd = new SQLiteCommand("INSERT INTO settings (title, content, created) VALUES('" +
                Key + "', '" + Value + "', '" + Todate() + "')", SqlConn);
            SqlCmd.ExecuteNonQuery();
            //SqlConn.Close();
        }

        /// <summary>
        /// Get the current value of the setting, or if it is not found, set the 
        /// setting to the default setting.
        /// </summary>
        /// <typeparam name="valueType"></typeparam>
        /// <param name="Key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public string GetValueOrDefault<valueType>(string Key, string defaultValue)
        {
            string value;

            // If the key exists, retrieve the value.
            if (SetCheck(Key))
            {
                value = GetValue(Key);
                if (value.Length == 0) return defaultValue;
                else return value;
            }
            // Otherwise, use the default value.
            else return defaultValue;
        }

        /// <summary>
        /// Date that vSongBook got installed on this PC
        /// </summary>
        public string Installed
        {
            get
            {
                return GetValueOrDefault<string>(install_date_Key, install_date_Default);
            }
            set
            {
                SetValue(install_date_Key, value.ToString());
            }
        }

        /// <summary>
        /// Name of the User of vSongBook for PC App
        /// </summary>
        public string AppUser
        {
            get
            {
                return GetValueOrDefault<string>(app_user_Key, app_user_Default);
            }
            set
            {
                SetValue(app_user_Key, value.ToString());
            }
        }

        /// <summary>
        /// Theme of vSongBook for PC App
        /// </summary>
        public int Theme
        {
            get
            {
                string vsb_option = GetValueOrDefault<string>(theme_Key, theme_Default);
                return Int32.Parse(vsb_option);
            }
            set
            {
                SetValue(theme_Key, value.ToString());
            }
        }

        /// <summary>
        /// Version of vSongBook for PC App
        /// </summary>
        public string VsbVersion
        {
            get
            {
                return GetValueOrDefault<string>(vsb_version_Key, vsb_version_Default);
            }
            set
            {
                SetValue(vsb_version_Key, value.ToString());
            }
        }

        /// <summary>
        /// Prefferred language for the user
        /// </summary>
        public string Language
        {
            get
            {
                return GetValueOrDefault<string>(language_Key, language_Default);
            }
            set
            {
                SetValue(language_Key, value.ToString());
            }
        }

        /// <summary>
        /// Show the startup page for a first time user
        /// </summary>
        public bool ShowStartpage
        {
            get
            {
                string vsb_option = GetValueOrDefault<string>(show_startpage_Key, show_startpage_Default);
                return SetBool(vsb_option);
            }
            set
            {
                SetValue(show_startpage_Key, GetBool(value));
            }
        }

        /// <summary>
        ///General font size for the rest of this app 
        /// </summary>
        public int FontSizeGeneral
        {
            get
            {
                string vsb_option = GetValueOrDefault<string>(general_font_size_Key, general_font_size_Default);
                return Int32.Parse(vsb_option);
            }
            set
            {
                SetValue(general_font_size_Key, value.ToString());
            }
        }

        /// <summary>
        /// General font type for the rest of the app
        /// </summary>
        public string FontTypeGeneral
        {
            get
            {
                return GetValueOrDefault<string>(general_font_type_Key, general_font_type_Default);
            }
            set
            {
                SetValue(general_font_type_Key, value.ToString());
            }
        }

        /// <summary>
        /// General Make text bold for this app.
        /// </summary>
        public bool FontBoldGeneral
        {
            get
            {
                string vsb_option = GetValueOrDefault<string>(general_font_bold_Key, general_font_bold_Default);
                return SetBool(vsb_option);
            }
            set
            {
                SetValue(general_font_bold_Key, GetBool(value));
            }
        }

        /// <summary>
        /// Selected book for editting 
        /// </summary>
        public int SelectedBook
        {
            get
            {
                string vsb_option = GetValueOrDefault<string>(selected_book_Key, selected_book_Default);
                return Int32.Parse(vsb_option);
            }
            set
            {
                SetValue(selected_book_Key, value.ToString());
            }
        }

        /// <summary>
        /// Selected song for editting
        /// </summary>
        public int SelectedSong
        {
            get
            {
                string vsb_option = GetValueOrDefault<string>(selected_song_Key, selected_song_Default);
                return Int32.Parse(vsb_option);
            }
            set
            {
                SetValue(selected_song_Key, value.ToString());
            }
        }

        /// <summary>
        /// Make text bold for the listed items
        /// </summary>
        public bool FontBoldList
        {
            get
            {
                string vsb_option = GetValueOrDefault<string>(list_font_bold_Key, list_font_bold_Default);
                return SetBool(vsb_option);
            }
            set
            {
                SetValue(list_font_bold_Key, GetBool(value));
            }
        }

        /// <summary>
        /// Font size for the song preview
        /// </summary>
        public int FontSizePreview
        {
            get
            {
                string vsb_option = GetValueOrDefault<string>(preview_font_size_Key, preview_font_size_Default);
                return Int32.Parse(vsb_option);
            }
            set
            {
                SetValue(preview_font_size_Key, value.ToString());
            }
        }

        /// <summary>
        /// Font type for song preview
        /// </summary>
        public string FontTypePreview
        {
            get
            {
                return GetValueOrDefault<string>(preview_font_type_Key, preview_font_type_Default);
            }
            set
            {
                SetValue(preview_font_type_Key, value.ToString());
            }
        }

        /// <summary>
        /// Make text bold for song preview
        /// </summary>
        public bool FontBoldPreview
        {
            get
            {
                string vsb_option = GetValueOrDefault<string>(project_font_bold_Key, project_font_bold_Default);
                return SetBool(vsb_option);
            }
            set
            {
                SetValue(preview_font_bold_Key, GetBool(value));
            }
        }

        /// <summary>
        /// Font size for song projection
        /// </summary>
        public int FontSizeProject
        {
            get
            {
                string vsb_option = GetValueOrDefault<string>(project_font_size_Key, project_font_size_Default);
                return Int32.Parse(vsb_option);
            }
            set
            {
                SetValue(project_font_size_Key, value.ToString());
            }
        }

        /// <summary>
        /// Font type for song Projection
        /// </summary>
        public string FontTypeProject
        {
            get
            {
                return GetValueOrDefault<string>(project_font_type_Key, project_font_type_Default);
            }
            set
            {
                SetValue(project_font_type_Key, value.ToString());
            }
        }

        /// <summary>
        /// Make text bold for song projection
        /// </summary>
        public bool FontBoldProject
        {
            get
            {
                string vsb_option = GetValueOrDefault<string>(project_font_bold_Key, project_font_bold_Default);
                return SetBool(vsb_option);
            }
            set
            {
                SetValue(project_font_bold_Key, GetBool(value));
            }
        }

        /// <summary>
        /// Mode of editting songs
        /// </summary>
        public bool ModeEdit
        {
            get
            {
                string vsb_option = GetValueOrDefault<string>(edit_mode_Key, edit_mode_Default);
                return SetBool(vsb_option);
            }
            set
            {
                SetValue(edit_mode_Key, GetBool(value));
            }
        }

        /// <summary>
        /// Mode of startup from last window closed
        /// </summary>
        public int LastWindowStartup
        {
            get
            {
                string vsb_option = GetValueOrDefault<string>(last_window_startup_Key, last_window_startup_Default);
                return Int32.Parse(vsb_option);
            }
            set
            {
                SetValue(last_window_startup_Key, value.ToString());
            }
        }

        /// <summary>
        /// Width of last window when closed
        /// </summary>
        public int LastWindowWidth
        {
            get
            {
                string vsb_option = GetValueOrDefault<string>(last_window_width_Key, last_window_width_Default);
                return Int32.Parse(vsb_option);
            }
            set
            {
                SetValue(last_window_width_Key, value.ToString());
            }
        }

        /// <summary>
        /// Height of last window closed
        /// </summary>
        public int LastWindowHeight
        {
            get
            {
                string vsb_option = GetValueOrDefault<string>(last_window_height_Key, last_window_height_Default);
                return Int32.Parse(vsb_option);
            }
            set
            {
                SetValue(last_window_height_Key, value.ToString());
            }
        }

        /// <summary>
        /// Mode of the user input i.e tablet or normal screen
        /// </summary>
        public bool ModeTablet
        {
            get
            {
                string vsb_option = GetValueOrDefault<string>(tablet_mode_Key, tablet_mode_Default);
                return SetBool(vsb_option);
            }
            set
            {
                SetValue(tablet_mode_Key, GetBool(value));
            }
        }

        /// <summary>
        /// Show help first every time vSongBook is opened
        /// </summary>
        public bool ShowHelpFirst
        {
            get
            {
                string vsb_option = GetValueOrDefault<string>(show_help_first_Key, show_help_first_Default);
                return SetBool(vsb_option);
            }
            set
            {
                SetValue(show_help_first_Key, GetBool(value));
            }
        }

        /// <summary>
        /// The song currently opened 
        /// </summary>
        public int CurrentSong
        {
            get
            {
                string vsb_option = GetValueOrDefault<string>(current_song_Key, current_song_Default);
                return Int32.Parse(vsb_option);
            }
            set
            {
                SetValue(current_song_Key, value.ToString());
            }
        }

        /// <summary>
        /// Allow all books to be searched when enabled
        /// </summary>
        public bool SearchAllBooks
        {
            get
            {
                string vsb_option = GetValueOrDefault<string>(search_allbooks_Key, search_allbooks_Default);
                return SetBool(vsb_option);
            }
            set
            {
                SetValue(search_allbooks_Key, GetBool(value));
            }
        }

        public string Todate()
        {
            return DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
        }

    }
}
