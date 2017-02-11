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

namespace OnePos.Persistance
{
    partial class OnePosEntities
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(OnePosEntities));


		//WRITE ANY SQLSERVER RELATED QUERIES HERE.
        public void SampleInsertCommend(int ID)
        {
            Database.ExecuteSqlCommand(string.Format("insert into emptable(empid) values({0})", ID));
        }

        public void InsertCommandforTaxRelation(Guid TaxGroupID,List<TaxConfiguration> Taxes)
        {

          //  Database.ExecuteSqlCommand("DELETE FROM  [ASSN_TAXCFG_TG] Where [TaxGroup_Id] = "+ TaxGroupID);

            foreach (var taxconfiguration in Taxes)
            {
                Database.ExecuteSqlCommand(string.Format("INSERT INTO [ASSN_TAXCFG_TG]([TaxGroup_Id],[TaxConfiguration_Id]) VALUES ({0},{1}) values({0})", TaxGroupID, taxconfiguration.Id));
            }
           
        }

        public void DeleteCommandforTaxRelation(Guid TaxID, Guid TaxGroupID)
        {
            //Database.ExecuteSqlCommand(string.Format("insert into emptable(empid) values({0})", ID));
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
