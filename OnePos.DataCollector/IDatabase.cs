using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using OnePos.Message.Model;


namespace OnePos.DataCollector
{
    public interface IDatabase
    {
        string UserName { get; set; }
        string Password { get; set; }
   
        DataTable ColumnsDataTable { get; set; }

        bool GetSqlqueryColumns(string query);

        IList<string> GetTablesName(); 
        DataTable GetTableColumns(string TableName);
        IList<string> GetColumns(string TableName, string Type); 
        DataTable GetData(string TableName);
        DataTable GetDataFromQuery(string SelectQuery);
        bool DropTable(string TableName); 
        int AppendRows(string TableName);
        int DeleteAllRows(string TableName);
        string ExportDataToDataSet(DataTable dataTable, string DestinationTbl, int batchSize);
        string ExportDataToTemporaryTable(DataTable dataTable, string DestinationTbl, int batchSize);
        string ExportDataToServer(DataTable dataTable, string DestinationTbl);
        bool AddColumn(string TableName);
        DateTime GetExpiryDate(string connectionString);  
        bool CreateTableFromQuery(string Query); 
        
    }
}
