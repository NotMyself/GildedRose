using GildedRose.Inventory.Domain.Entities;
using GildedRose.Inventory.Domain.Entities.Validation;
using System.Linq;
using Xunit;

namespace GildedRose.Tests
{
    /// <summary>
    /// Unit tests to cover the InventoryValidator class.
    /// </summary>
    public class InventoryValidatorTests
    {
        public InventoryValidatorTests()
            : base()
        {
        }

        [Fact]
        public void IsValidTest_DepreciatingItem_Valid()
        {
            InventoryItem item = InventoryTestUtility.CreateDepreciatingItem(10, 20) as InventoryItem;

            InventoryItemValidator validator = new InventoryItemValidator();
            bool isValid = validator.IsValid(item);

            Assert.True(isValid);
        }

        [Fact]
        public void IsValidTest_AppreciatingItem_Valid()
        {
            InventoryItem item = InventoryTestUtility.CreateAppreciatingItem(2, 0) as InventoryItem;

            InventoryItemValidator validator = new InventoryItemValidator();
            bool isValid = validator.IsValid(item);

            Assert.True(isValid);
        }

        [Fact]
        public void IsValidTest_AppreciatingItem_VariableQualityRate_Valid()
        {
            InventoryItem item = InventoryTestUtility.CreateAppreciatingItemWithVariableQualityRate(9, 20) as InventoryItem;

            InventoryItemValidator validator = new InventoryItemValidator();
            bool isValid = validator.IsValid(item);

            Assert.True(isValid);
        }

        [Fact]
        public void IsValidTest_FixedQualityItem_Valid()
        {
            InventoryItem item = InventoryTestUtility.CreateFixedQualityItem(0, 80) as InventoryItem;

            InventoryItemValidator validator = new InventoryItemValidator();
            bool isValid = validator.IsValid(item);

            Assert.True(isValid);
        }

        [Fact]
        public void IsValidTest_Invalid_NoOpenEndedMaxBoundary()
        {
            InventoryItem item = InventoryTestUtility.CreateDepreciatingItem(10, 20) as InventoryItem;
            item.QualityRules.First(qr => qr.MaxSellIn == null).MaxSellIn = 100;

            InventoryItemValidator validator = new InventoryItemValidator();
            bool isValid = validator.IsValid(item);

            Assert.False(isValid);
        }

        [Fact]
        public void IsValidTest_Invalid_NoOpenEndedMinBoundary()
        {
            InventoryItem item = InventoryTestUtility.CreateDepreciatingItem(10, 20) as InventoryItem;
            item.QualityRules.First(qr => qr.MinSellIn == null).MinSellIn = 1;

            InventoryItemValidator validator = new InventoryItemValidator();
            bool isValid = validator.IsValid(item);

            Assert.False(isValid);
        }

        [Fact]
        public void IsValidTest_Invalid_MissingName_Empty()
        {
            InventoryItem item = InventoryTestUtility.CreateDepreciatingItem(10, 20) as InventoryItem;
            item.Name = "";

            InventoryItemValidator validator = new InventoryItemValidator();
            bool isValid = validator.IsValid(item);

            Assert.False(isValid);
        }

        [Fact]
        public void IsValidTest_Invalid_MissingName_Whitespace()
        {
            InventoryItem item = InventoryTestUtility.CreateDepreciatingItem(10, 20) as InventoryItem;
            item.Name = " ";

            InventoryItemValidator validator = new InventoryItemValidator();
            bool isValid = validator.IsValid(item);

            Assert.False(isValid);
        }

        [Fact]
        public void IsValidTest_Invalid_MissingName_Null()
        {
            InventoryItem item = InventoryTestUtility.CreateDepreciatingItem(10, 20) as InventoryItem;
            item.Name = null;

            InventoryItemValidator validator = new InventoryItemValidator();
            bool isValid = validator.IsValid(item);

            Assert.False(isValid);
        }

        [Fact]
        public void ValidateTest_Valid()
        {
            InventoryItem item = InventoryTestUtility.CreateDepreciatingItem(10, 20) as InventoryItem;

            InventoryItemValidator validator = new InventoryItemValidator();
            validator.Validate(item);
        }

        [Fact]
        public void ValidateTest_Invalid()
        {
            InventoryItem item = InventoryTestUtility.CreateDepreciatingItem(10, 20) as InventoryItem;
            item.Name = null;

            InventoryItemValidator validator = new InventoryItemValidator();
            Assert.Throws<ValidationException>(() => validator.Validate(item));
        }
    }
}
