using System.Linq;

namespace GildedRose.Inventory.Domain.Entities.Validation
{
    /// <summary>
    /// Responsible for validating inventory items.
    /// </summary>
    /// <remarks>
    /// Note that validation is probably not required for this application given its current scope,
    /// but including it here as an example validation approach.
    /// </remarks>
    public class InventoryItemValidator : ValidatorBase<InventoryItem>
    {
        public override bool IsValid(InventoryItem inventoryItem)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(inventoryItem.Name))
            {
                isValid = false;
                ValidationErrors.Add("Name must be specified.");
            }

            if (inventoryItem.QualityRules.Count(qr => qr.MinSellIn == null) != 1)
            {
                isValid = false;
                ValidationErrors.Add("A quality rule with no lower bound for the range of applicable sell-in values must be specified.");
            }
            if (inventoryItem.QualityRules.Count(qr => qr.MaxSellIn == null) != 1)
            {
                isValid = false;
                ValidationErrors.Add("A quality rule with no upper bound for the range of applicable sell-in values must be specified.");
            }

            return isValid;
        }
    }
}
