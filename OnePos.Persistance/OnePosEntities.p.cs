using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using OnePos.Domain;
using log4net;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.EntityClient; 

namespace OnePos.Persistance
{
    partial class OnePosEntities 
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(OnePosEntities));


        public OnePosEntities(DbConnection connectionString, bool contextOwnsConnection = true)
            : base(connectionString, contextOwnsConnection)
        {
        }
        

        public OnePosEntities CreateEntitiesForSpecificDatabaseName(string dataSource, string databaseName, bool contextOwnsConnection = true)
        {
            //Initialize the SqlConnectionStringBuilder
            SqlConnectionStringBuilder sqlConnectionBuilder = new SqlConnectionStringBuilder();
            sqlConnectionBuilder.DataSource = dataSource;
            sqlConnectionBuilder.InitialCatalog = databaseName;
            sqlConnectionBuilder.IntegratedSecurity = true;
            sqlConnectionBuilder.MultipleActiveResultSets = true;
            string sqlConnectionString = sqlConnectionBuilder.ConnectionString;

            //Initialize the EntityConnectionStringBuilder
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
            entityBuilder.Provider = "System.Data.SqlClient";
            entityBuilder.ProviderConnectionString = sqlConnectionString;

            //Set the Metadata location.
            entityBuilder.Metadata = @"res://*/OnePosModel.csdl|res://*/OnePosModel.ssdl|res://*/OnePosModel.msl";

            //Create entity connection
            EntityConnection connection = new EntityConnection(entityBuilder.ConnectionString);

            return new OnePosEntities(connection);
        }


        //WRITE ANY SQLSERVER RELATED QUERIES HERE.
        public void SampleInsertCommend(int ID)
        {
            Database.ExecuteSqlCommand(string.Format("insert into emptable(empid) values({0})", ID));
        }

        public long CreateStore(Store store)
        {

            try { 

                var instQuery = "INSERT INTO [app].[OnePosStores]([StoreName],[StoreOwnerName],[StoreUniqueKey],[StoreAddress],[PhoneNumber],[LicenseExpiry],[AdminUsername],[AdminPassword],[EmailId],[IsActive],[StoreStatus],[IsFirstLogin],[StoreTypeId])  output INSERTED.ID VALUES(@StoreName,@StoreOwnerName,@StoreUniqueKey,@StoreAddress,@PhoneNumber,@LicenseExpiry,@AdminUsername,@AdminPassword,@EmailId,@IsActive,@StoreStatus,@IsFirstLogin,@StoreTypeId)";

                long storeId = 0;
                using (var con = new SqlConnection(Database.Connection.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandTimeout = 7200;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = instQuery;

                    cmd.Parameters.AddWithValue("@StoreName", store.StoreName);
                    cmd.Parameters.AddWithValue("@StoreOwnerName", store.StoreOwnerName);
                    cmd.Parameters.AddWithValue("@StoreUniqueKey", store.StoreUniqueKey);
                    cmd.Parameters.AddWithValue("@StoreAddress", store.StoreAddress);
                    cmd.Parameters.AddWithValue("@PhoneNumber", store.PhoneNumber);
                    cmd.Parameters.AddWithValue("@LicenseExpiry", store.LicenseExpiry);
                    cmd.Parameters.AddWithValue("@AdminUsername", store.AdminUsername);
                    cmd.Parameters.AddWithValue("@AdminPassword", store.AdminPassword);
                    cmd.Parameters.AddWithValue("@EmailId", store.EmailId);
                    cmd.Parameters.AddWithValue("@IsActive", store.IsActive == true ? 1 : 0);
                    cmd.Parameters.AddWithValue("@StoreStatus", store.StoreStatusId);
                    cmd.Parameters.AddWithValue("@IsFirstLogin", store.IsFirstLogin == true ? 1 : 0);
                    cmd.Parameters.AddWithValue("@StoreTypeId", store.StoreTypeId);  

                    con.Open();
                    cmd.Connection = con;
                    storeId = (long)cmd.ExecuteScalar();
                    con.Close();
                }  
                return storeId;

            } catch (Exception ex) {
                return 0;
            } 
            return 0;
        }

        public long CreateStoreAccessModules(StoreAccessModules storeaccessmodules)
        {

            try
            {

                var instQuery = "INSERT INTO [app].[StoreAccessModules]([IsInventoryAccess],[IsUserManagementAccess],[IsReportsAccess],[IsTimeSheetManagementAccess],[IsProductManagementAccess],[StoreId],[NumberOfBranchesAllow]) output INSERTED.AccessModuleId VALUES (@IsInventoryAccess,@IsUserManagementAccess,@IsReportsAccess,@IsTimeSheetManagementAccess,@IsProductManagementAccess,@StoreId,@NumberOfBranchesAllow)";

                long storeAccessModulesId = 0;
                using (var con = new SqlConnection(Database.Connection.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandTimeout = 7200;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = instQuery;

                    cmd.Parameters.AddWithValue("@IsInventoryAccess", storeaccessmodules.IsInventoryAccess == true ? 1 : 0);
                    cmd.Parameters.AddWithValue("@IsUserManagementAccess", storeaccessmodules.IsUserManagementAccess == true ? 1 : 0);
                    cmd.Parameters.AddWithValue("@IsReportsAccess", storeaccessmodules.IsReportsAccess == true ? 1 : 0);
                    cmd.Parameters.AddWithValue("@IsTimeSheetManagementAccess", storeaccessmodules.IsTimeSheetManagementAccess == true ? 1 : 0);
                    cmd.Parameters.AddWithValue("@IsProductManagementAccess", storeaccessmodules.IsProductManagementAccess == true ? 1 : 0);
                    cmd.Parameters.AddWithValue("@StoreId", storeaccessmodules.StoreId);
                    cmd.Parameters.AddWithValue("@NumberOfBranchesAllow", storeaccessmodules.NumberOfBranchesAllow);
                      
                    con.Open();
                    cmd.Connection = con;
                    storeAccessModulesId = (long)cmd.ExecuteScalar();
                    con.Close();
                }
                return storeAccessModulesId;

            }
            catch (Exception ex)
            {
                return 0;
            }
            return 0;
        }

        public bool UpdateStore(Store store)
        {
            try {
                var updateQuery = string.Format(@"UPDATE [app].[OnePosStores] SET [StoreName] = '{0}',[StoreOwnerName] = '{1}',[StoreAddress] = '{2}',[PhoneNumber] = '{3}',[LicenseExpiry] = '{4}',[IsActive] = {5}  WHERE ID= {6}",
                                                    store.StoreName,
                                                    store.StoreOwnerName,
                                                    store.StoreAddress,
                                                    store.PhoneNumber,
                                                    store.LicenseExpiry,
                                                    store.IsActive == true ? 1 : 0, store.ID);
                Database.ExecuteSqlCommand(updateQuery);
                return true;
            } catch (Exception ex) {
                return false;
            } 
            return false;
        }


        public DataTable GetOnePosStores()
        {
            DataTable dt = new DataTable();
            using (var con = new SqlConnection(Database.Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 7200;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT [ID],[StoreName],[StoreOwnerName],[StoreUniqueKey],[StoreAddress],[PhoneNumber],[LicenseExpiry],[AdminUsername],[AdminPassword],[EmailId],[IsActive],[StoreStatus],[IsFirstLogin],[MainDBConnectionId],[BackupDBConnectionId],opst.[StoreTypeId],opst.[Name] as StoreTypeName FROM [app].[OnePosStores] ops inner join [code].[OnePosStoreType] opst on ops.StoreTypeId=opst.StoreTypeId";

                con.Open();
                cmd.Connection = con;
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
            }
            return dt;
        }

        public bool CreateVerticalDatabaseConnections(string Address, string DatabaseName, string UserName, string Password, int StoreTypeId, int IsMainDB)
        {
            try
            {

                var insertQuery = string.Format(@"INSERT INTO [app].[OnePosDatabaseConnection]([Address],[UserName],[Password],[DatabaseName],[IsMainDB],[StoreTypeId]) VALUES ('{0}','{1}','{2}','{3}',{4},{5})", Address, UserName, Password, DatabaseName, IsMainDB, StoreTypeId);

                Database.ExecuteSqlCommand(insertQuery);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        public DataTable GetOnePosStoreTypes()
        {
            DataTable dt = new DataTable();
            using (var con = new SqlConnection(Database.Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 7200;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT [StoreTypeId],[Name],[Description],[VerticalDatabaseName] FROM [code].[OnePosStoreType]";
                 
                con.Open();
                cmd.Connection = con;
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
            }
            return dt;
        }

        public DataTable GetOnePosStoreDatabases()
        {
            DataTable dt = new DataTable();
            using (var con = new SqlConnection(Database.Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 7200;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT [ConnectionId],[Address],[UserName],[Password],[DatabaseName],[IsMainDB],[StoreTypeId]FROM [app].[OnePosDatabaseConnection]";

                con.Open();
                cmd.Connection = con;
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
            }
            return dt;
        }

        public bool UpdateOnePosStoreStatus(long StoreId, int StatusId)
        {
            try
            {
                var updateQuery = string.Format(@"UPDATE [app].[OnePosStores] SET  [StoreStatus] = {0}  WHERE ID= {1}", StatusId, StoreId);
                Database.ExecuteSqlCommand(updateQuery);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }


        public bool UpdateOnePosStoreDatabaseConnections(long StoreId, int MainDBConnectionId, int BackupDBConnectinId)
        {
            try
            {
                var updateQuery = string.Format(@"UPDATE [app].[OnePosStores] SET  [MainDBConnectionId]={0}, [BackupDBConnectionId]={1}  WHERE ID= {2}", MainDBConnectionId, BackupDBConnectinId, StoreId);
                Database.ExecuteSqlCommand(updateQuery);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        public DataTable GetStoreAccessModules(long storeId)
        {
            DataTable dt = new DataTable();
            using (var con = new SqlConnection(Database.Connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 7200;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT [AccessModuleId],[IsInventoryAccess],[IsUserManagementAccess],[IsReportsAccess],[IsTimeSheetManagementAccess],[IsProductManagementAccess],[StoreId],[NumberOfBranchesAllow]FROM [app].[StoreAccessModules] WHERE [StoreId]=" + storeId;

                con.Open();
                cmd.Connection = con;
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
            }
            return dt;
        }

        public void InsertCommandforTaxRelation(Guid TaxGroupID,List<TaxConfiguration>Taxes)
        {
           

            var sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("BEGIN TRANSACTION");
            sqlCommand.AppendLine(string.Format("DELETE FROM ASSN_TAXCFG_TG WHERE TaxGroup_Id = '{0}' ", TaxGroupID));

            foreach (var Taxconf in Taxes)
            {
                sqlCommand.AppendLine(string.Format("INSERT INTO [ASSN_TAXCFG_TG]([TaxGroup_Id],[TaxConfiguration_Id]) values('{0}','{1}')", TaxGroupID, Taxconf.Id));
            }

            sqlCommand.AppendLine("COMMIT TRANSACTION");

            string strCommandText = sqlCommand.ToString();

            Database.ExecuteSqlCommand(sqlCommand.ToString());

        }

        public void BulkQuerySample(List<string> QueriesList)
        {
            
            var sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("BEGIN TRANSACTION");
            sqlCommand.AppendLine(string.Format("DELETE FROM UserRoles WHERE UserID = {0} ", 1));

            for (int i = 0; i < QueriesList.Count; i++) {
                sqlCommand.AppendLine(string.Format("insert into userroles(userId,roleId) values({0},{1})", 1,2));
             }
            
            sqlCommand.AppendLine("COMMIT TRANSACTION");

            string strCommandText = sqlCommand.ToString();

            Database.ExecuteSqlCommand(sqlCommand.ToString());
        }


        #region OnePosEntities Members

        public override int SaveChanges()
        {
            List<IAuditable> createdEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added && e.Entity is IAuditable)
                .Select(e => e.Entity)
                .Cast<IAuditable>()
                .ToList();
            List<IAuditable> modifiedEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified && e.Entity is IAuditable)
                .Select(e => e.Entity)
                .Cast<IAuditable>()
                .ToList();
            if (createdEntities.Any() || modifiedEntities.Any())
            {
                string userName;
                if (HttpContext.Current == null ||
                    HttpContext.Current.User == null ||
                    string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
                {
                    userName = "System";
                }
                else
                {
                    userName = HttpContext.Current.User.Identity.Name;
                }
                foreach (IAuditable createdEntity in createdEntities)
                {
                    DateTime now = DateTime.Now;
                    createdEntity.CreatedBy = userName;
                    createdEntity.CreatedDate = now;
                    createdEntity.ModifiedBy = userName;
                    createdEntity.ModifiedDate = now;
                }
                foreach (IAuditable modifiedEntity in modifiedEntities)
                {
                    modifiedEntity.ModifiedBy = userName;
                    modifiedEntity.ModifiedDate = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }

        #endregion
    }
}
