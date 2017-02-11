using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using OnePos.Message.Model;
using System.Globalization;
using System.Configuration;
using OnePos.Domain.Encryption;
using System.Runtime.Serialization.Formatters.Binary; 
using Microsoft.SqlServer.Management.Common;


namespace OnePos.DataCollector
{
    public class SqlServerHandler : IDatabase
    {
        private string connectionString = string.Empty;

        public string UserName { get; set; }
        public string Password { get; set; } 
        public DataTable ColumnsDataTable { get; set; }

        public SqlServerHandler(string ConnectionString)
        {
            connectionString = ConnectionString;
        }


        public IList<string> GetTablesName()
        {
            List<string> Tables = new List<string>();
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("SELECT ''+SCHEMA_NAME(schema_id)+'.'+name+''AS name FROM sys.tables order by name Asc", con);
                con.Open();
                System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Tables.Add(reader["name"].ToString());
                }
                con.Close();

            }
            catch (Exception ex)
            {

            }
            return Tables;
        }

        public DataTable GetTableColumns(string TableName)
        {
            DataTable dt = new DataTable();
            string tableName = string.Empty;
            try
            {
                if (TableName.Contains('.'))
                {
                    string[] words = TableName.Split('.');
                    tableName = words[1];
                    if (tableName.Contains('['))
                    {
                        tableName = tableName.Replace("[", string.Empty).Replace("]", string.Empty);
                    }
                }
                else
                {
                    if (tableName.Contains('['))
                    {
                        tableName = tableName.Replace("[", string.Empty).Replace("]", string.Empty);
                    }
                    else
                    {

                        tableName = TableName;
                    }
                }
                string query = "SELECT COLUMN_NAME as Name, DATA_TYPE as DataType, case when isnull(CHARACTER_MAXIMUM_LENGTH,0) > 2064 then 2064 else isnull(CHARACTER_MAXIMUM_LENGTH,0) end AS ColumnLength FROM  INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tableName + "'";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.Close();

            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public IList<string> GetColumns(string TableName, string Type)
        {
            List<string> Columns = new List<string>();
            string tableName = string.Empty;
            try
            {
                if (TableName.Contains('.'))
                {
                    string[] words = TableName.Split('.');
                    tableName = words[1];
                    if (tableName.Contains('['))
                    {
                        tableName = tableName.Replace("[", string.Empty).Replace("]", string.Empty);
                    }
                }
                else
                {
                    if (tableName.Contains('['))
                    {
                        tableName = tableName.Replace("[", string.Empty).Replace("]", string.Empty);
                    }
                    else
                    {

                        tableName = TableName;
                    }
                }
                string query = string.Empty;
                //if (Type == "intVarchar")
                //{
                //    query = "SELECT COLUMN_NAME as Name FROM  INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tableName + "'" + " " + "and ( DATA_TYPE='int'" + " or  DATA_TYPE='bigint'" + " or  DATA_TYPE='float'" + " or  DATA_TYPE='decimal')";
                //}
                if (Type == "datetime")
                {
                    query = "SELECT COLUMN_NAME as Name FROM  INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tableName + "'" + " " + "and  (DATA_TYPE='datetime'" + " or  DATA_TYPE='date'" + " or  DATA_TYPE='time'" + " or  DATA_TYPE='datetime2')";
                }
                if (Type == "varchar")
                {
                    query = "SELECT COLUMN_NAME as Name FROM  INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tableName + "'" + " " + "and  (DATA_TYPE='varchar'" + " or  DATA_TYPE='nvarchar'" + " or  DATA_TYPE='text')";
                }

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Columns.Add(reader["Name"].ToString());
                }
                con.Close();

            }
            catch (Exception ex)
            {

            }
            return Columns;
        }
         
        public bool DropTable(string TableName)
        {
            bool retVal = false;
            try
            {
                string cmdText = " drop table " + TableName;
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(cmdText, con);
                con.Open();
                cmd.ExecuteNonQuery();
                retVal = true;
                con.Close();


            }
            catch (Exception ex)
            {
                return retVal;
            }
            return retVal;
        } 
       
        public int AppendRows(string TableName)
        {
            throw new NotImplementedException();
        }

        public int DeleteAllRows(string TableName)
        {
            int recordAffected = 0;
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("Delete from " + TableName + "", con);
                con.Open();
                recordAffected = cmd.ExecuteNonQuery();

                con.Close();


            }
            catch (Exception ex)
            {
                return recordAffected;
            }
            return recordAffected;

        }

        public bool ExecuteSQLQuery(string Query)
        {
            bool retVal = false;
            try
            {

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                   // cmd.ExecuteNonQuery(); 
                    Microsoft.SqlServer.Management.Smo.Server server = new Microsoft.SqlServer.Management.Smo.Server(new ServerConnection(con));
                   server.ConnectionContext.ExecuteNonQuery(Query);
                   con.Close();
                }

                retVal = true;
            }
            catch (Exception ex)
            {
                return retVal;
            }
            return retVal; 
        }

        public string ExportDataToDataSet(DataTable dataTable, string DestinationTbl, int batchSize)
        {
            string retVal = string.Empty;
            try
            {
                DataTable dtInsertRows = dataTable;

                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                
                using (SqlBulkCopy sbc = new SqlBulkCopy(connectionString,SqlBulkCopyOptions.FireTriggers))
                {
                    sbc.DestinationTableName = DestinationTbl;

                    // Number of records to be processed in one go
                    sbc.BatchSize = batchSize;

                    // Add your column mappings here
                    //sbc.ColumnMappings.Add("field1", "field3");
                    // sbc.ColumnMappings.Add("foo", "bar");

                    foreach (DataColumn dc in dataTable.Columns) {
                        sbc.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);
                    }



                    // Finally write to server
                    sbc.WriteToServer(dtInsertRows);
                }
                retVal = "Success";
                return retVal;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ExportDataToTemporaryTable(DataTable dataTable, string DestinationTbl, int batchSize)
        {
            string retVal = string.Empty;
            try
            {
                DataTable dtInsertRows = dataTable;

               // string connectionString = connectionString;

                using (SqlBulkCopy sbc = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.FireTriggers))
                {
                    sbc.DestinationTableName = DestinationTbl;

                    // Number of records to be processed in one go
                    sbc.BatchSize = batchSize;

                    // Add your column mappings here
                    //sbc.ColumnMappings.Add("field1", "field3");
                    // sbc.ColumnMappings.Add("foo", "bar");

                    foreach (DataColumn dc in dataTable.Columns)
                    {
                        sbc.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);
                    }



                    // Finally write to server
                    sbc.WriteToServer(dtInsertRows);
                }
                retVal = "Success";
                return retVal;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
 
        public string ExportDataToServer(DataTable dataTable, string DestinationTbl)
        {
            string retVal = string.Empty;
            //DataTable DT = GetTableColumns(DestinationTbl);

            try
            {
                DataTable dtInsertRows = dataTable; 

                using (SqlBulkCopy sbc = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.KeepIdentity | SqlBulkCopyOptions.FireTriggers))
                {
                    sbc.DestinationTableName = DestinationTbl; 
                    sbc.WriteToServer(dtInsertRows);
                }
                retVal = "Success";
                return retVal;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        private static DateTime? ValidateTime(string time, string format)
        {
            DateTime result;
            if (!DateTime.TryParseExact(time, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result)) return null;

            return result;
        }

        public bool AddColumn(string TableName)
        {
            bool isTrue = false;
            string query = "alter table [" + TableName + "] add [SubmissionDataId] int default 0 NOT NULL";
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                isTrue = true;
                con.Close();


            }
            catch (Exception ex)
            {
                return isTrue;
            }
            return isTrue;
        }


        public DataTable GetData(string TableName)
        {
            DataTable dt = new DataTable();
            try
            {


                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM  " + TableName, con);
                con.Open();
                System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.Close();

            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public DataTable GetDataFromQuery(string SelectQuery)
        {
            DataTable dt = new DataTable();
            try
            {


                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(SelectQuery, con);
                con.Open();
                System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.Close();

            }
            catch (Exception ex)
            {

            }
            return dt;
        }


        public DateTime GetExpiryDate(string connectionString)
        {
            DataTable dt = new DataTable();
            TwoWayEncryptionDecryption Decrypt = new TwoWayEncryptionDecryption();
            string expiryDate = string.Empty;
            string gracePeriod = string.Empty;
            int gracePeriodExpiry;
            DateTime licenseExpiryDate = DateTime.MinValue;
            try
            {
                string query = "SELECT LicenseExpiry FROM OnePosStores";

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                /* Decrypt the Expiry Date and grace period string */
                expiryDate = Decrypt.Decrypt((from DataRow dr in dt.Rows select (string)dr["LicenseExpiry"]).FirstOrDefault());
                //gracePeriod = Decrypt.Decrypt((from DataRow drG in dt.Rows select (string)drG["GracePeriod"]).FirstOrDefault());

                /* Convert Expiry Date into Datetime and grace period in integer values*/
                DateTime.TryParse(expiryDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out licenseExpiryDate);
               // int.TryParse(gracePeriod, out gracePeriodExpiry);
                licenseExpiryDate = licenseExpiryDate.AddDays(3); ///NEED TO CHANGE THIS GRACE PERIOD..


                con.Close();
            }

            catch (Exception ex)
            {

            }
            return licenseExpiryDate;
        }

     
        public static DataTable Deserialize(byte[] buffer)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream(buffer);
            System.Runtime.Serialization.IFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream) as DataTable;
        }
     
        public bool GetSqlqueryColumns(string query)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
 
    }
}
