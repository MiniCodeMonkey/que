using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Collections;

namespace Que.Server.PlaylistManagerNS
{
    public class DataBase : IDataBase
    {
        private String DBconnection;
        private static readonly DataBase instance = new DataBase();
                
        public static DataBase GetInstance()
        {
                return instance;            
        }

        /// <summary>
        /// Default constructor for the DB class
        /// </summary>
        private DataBase()
        {
            DBconnection = "Data Source=QDatabase.s3db";
        }

        /// <summary>
        /// Returns the number of times an artist is in the history within a certain time
        /// </summary>
        /// <param name="artist">The artist to look for</param>
        /// <param name="afterTime">The time which to go back in history</param>
        /// <returns></returns>
        public Boolean TrackInHistory(string trackName, DateTime afterTime)
        {
            String sql = "SELECT COUNT(*) FROM History WHERE TrackName=@name AND Timestamp<@time";
            Boolean success = true;
            SQLiteConnection cnn = new SQLiteConnection(DBconnection);
            cnn.Open();
            SQLiteCommand command = new SQLiteCommand(cnn);
            command.CommandText = sql;
            command.Parameters.Add("@name", DbType.String).Value = trackName;
            command.Parameters.Add("@time", DbType.DateTime).Value = afterTime;

            object value = command.ExecuteScalar();
            cnn.Close();

            PurgeHistory();

            int numberOfTracksInHistory = Convert.ToInt32(value.ToString());

            if (numberOfTracksInHistory > 0)
            {
                success = false;
            }

            return success;
        }

        public void InsertToHistory(string trackName, string trackArtist)
        {
            Console.WriteLine(trackName + " added to history");
            string sql = "INSERT INTO History(TrackName, TrackArtist, Timestamp) VALUES (@trackName, @trackArtist, datetime('now'))";

            SQLiteConnection cnn = new SQLiteConnection(DBconnection);
            cnn.Open();
            SQLiteCommand command = new SQLiteCommand(cnn);
            command.CommandText = sql;
            command.Parameters.Add("@trackName", DbType.String).Value = trackName;
            command.Parameters.Add("@trackArtist", DbType.String).Value = trackArtist;
            command.ExecuteNonQuery();
            cnn.Close();
        }

        private void PurgeHistory()
        {
            string sql = "DELETE FROM History WHERE Timestamp < @date";
            DateTime afterTime = DateTime.Now.Subtract(TimeSpan.FromHours(24));

            SQLiteConnection cnn = new SQLiteConnection(DBconnection);
            cnn.Open();

            SQLiteCommand command = new SQLiteCommand(cnn);
            command.CommandText = sql;
            command.Parameters.Add("@date", DbType.DateTime).Value = afterTime;
            command.ExecuteNonQuery();

            cnn.Close();

        }
                

        #region Unused methods
        /*
        /// <summary>
        /// Allows the programmer to interact with the database for purposes other than a query.
        /// </summary>
        /// <param name="sql">The SQL to be run.</param>
        /// <returns>An Integer containing the number of rows updated.</returns>
        private int ExecuteNonQuery(string sql)
        {
            SQLiteConnection cnn = new SQLiteConnection(DBconnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = sql;
            int rowsUpdated = mycommand.ExecuteNonQuery();
            cnn.Close();

            return rowsUpdated;
        } 
         
        /// <summary>
        /// Allows the programmer to easily insert into the DB
        /// </summary>
        /// <param name="tableName">The table into which we insert the data.</param>
        /// <param name="data">A dictionary containing the column names and data for the insert.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        private bool Insert(String tableName, Dictionary<String, String> data)
        {
            String columns = "";
            String values = "";
            Boolean returnCode = true;

            foreach (KeyValuePair<String, String> val in data)
            {
                columns += String.Format(" {0},", val.Key.ToString());
                values += String.Format(" '{0}',", val.Value);
            }
            columns = columns.Substring(0, columns.Length - 1);
            values = values.Substring(0, values.Length - 1);

            try
            {
                this.ExecuteNonQuery(String.Format("insert into {0}({1}) values({2});", tableName, columns, values));
            }
            catch (Exception fail)
            {
                System.Windows.Forms.MessageBox.Show(fail.Message);
                returnCode = false;
            }

            return returnCode;
        }
         
        /// <summary>
        /// Returns a single item from the database
        /// </summary>
        /// <param name="sql">The query to execute</param>
        /// <returns>A string</returns>
        public String GetSingleItem(String sql)
        {
            SQLiteConnection cnn = new SQLiteConnection(DBconnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = sql;
            object value = mycommand.ExecuteScalar();
            cnn.Close();

            if (value != null)
            {
                return value.ToString();
            }

            return "";
        }

        /// <summary>
        ///     Single Param Constructor for specifying the DB file.
        /// </summary>
        /// <param name="inputFile">The File containing the DB</param>
        public DB(String inputFile)
        {
            DBconnection = String.Format("Data Source={0}", inputFile);
        }

        /// <summary>
        /// Acquire data from the database
        /// </summary>
        /// <param name="sql">The query to run</param>
        /// <returns>A datable containing the result set</returns>
        public DataTable GetDataTable(String sql)
        {
            DataTable dt = new DataTable();

            try
            {
                SQLiteConnection cnn = new SQLiteConnection(DBconnection);
                cnn.Open();
                SQLiteCommand command = new SQLiteCommand(cnn);
                command.CommandText = sql;
                SQLiteDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                
                reader.Close();
                cnn.Close();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            return dt;
        }
        
        public Boolean Update(String tableName, Dictionary<String, String> data, String where)
        {
            String vals = String.Empty;
            Boolean returnCode = true;

            if (data.Count >= 1)
            {
                foreach (KeyValuePair<String, String> val in data)
                {
                    vals += String.Format(" {0} = '{1}',", val.Key.ToString(), val.Value.ToString());
                }
                vals = vals.Substring(0, vals.Length - 1);
            }
            try
            {
               
                this.ExecuteNonQuery(String.Format("update {0} set {1} where {2};", tableName, vals, where));
            }
            catch
            {
                returnCode = false;
            }
            return returnCode;
        }       

        /// <summary>
        /// Allows the programmer to easily delete rows from the DB.
        /// </summary>
        /// <param name="tableName">The table from which to delete.</param>
        /// <param name="where">The where clause for the delete.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool Delete(String tableName, String where)
        {
            Boolean returnCode = true;
            try
            {
                this.ExecuteNonQuery(String.Format("delete from {0} where {1};", tableName, where));
            }
            catch (Exception fail)
            {
                System.Windows.Forms.MessageBox.Show(fail.Message);
                returnCode = false;
            }
            return returnCode;
        }
        */

        #endregion
    }
}
