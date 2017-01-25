using System; 

namespace OnePos.Message.Model
{
    public class Product :IAuditable
    {
        public byte[] Image { get; set; }
        public string Color { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public int PriceMethod { get; set; }
        public bool PromptForPrice { get; set; }

        public bool IsGiftCard { get; set; }
        public double PricePerUnitOfWeight { get; set; }

        public bool UseWeightPricing { get; set; }
        public double UnitOfWeightSize { get; set; }

        public bool CountsAsSalesRevenue { get; set; }

        public double Price { get; set; }

        public bool RemoveAtZeroCount { get; set; }

        public bool IsAgeRestrict { get; set; }

        public bool IsDisplayOnBilling { get; set; }

        public string Metaproductdata { get; set; }

        public long Downtick { get; set; }
        public int MaxFloorQty { get; set; }

        public int MenuPosition { get; set; }

        public string Sku { get; set; }
        public string Plu { get; set; }

        public string Upc { get; set; }

        public string LongName { get; set; }

        public int CalorieCount { get; set; }

        public Guid StoreId { get; set; }

        public Guid RecipeId { get; set; }

        public Guid RevenueTypeId { get; set; }

        public Guid OrderedRecipeId { get; set; }

        public Guid SurchargeGroupId { get; set; }

        public Guid ProductGroupPrinterId { get; set; }

        public Guid TaxGroupId { get; set; }

        public Guid InclusiveTipRateId { get; set; }

        public Guid ExtendedBoolTableId { get; set; }
        public Guid ExtendedStringTableId { get; set; }
        public Guid ExtendedDecimalTableId { get; set; }
        public Guid ExtendedIntTableId { get; set; }
        public Guid ExtendedLinkTable1Id { get; set; }
        public Guid ExtendedLinkTable2Id { get; set; } 

        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
