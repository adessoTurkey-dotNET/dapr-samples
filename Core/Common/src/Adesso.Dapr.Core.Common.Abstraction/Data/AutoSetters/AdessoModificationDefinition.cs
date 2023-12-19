namespace Adesso.Dapr.Core.Common.Abstraction.Data.AutoSetters
{
    public sealed class AdessoModificationDefinition
    {
        public AdessoModificationDefinition()
        {
        }

        public AdessoModificationDefinition(
            AdessoModificationDefinitionItem modifiedBy,
            AdessoModificationDefinitionItem modifiedOn)
        {
            this.ModifiedBy = modifiedBy;
            this.ModifiedOn = modifiedOn;
        }

        public AdessoModificationDefinitionItem ModifiedBy { get; init; }
        public AdessoModificationDefinitionItem ModifiedOn { get; init; }
    }

    public class AdessoModificationDefinitionItem
    {
        public AdessoModificationDefinitionItem(
            string propertyName,
            bool overrideExisting = true)
        {
            this.PropertyName = propertyName;
            this.OverrideExisting = overrideExisting;
        }

        public string PropertyName { get; }
        public bool OverrideExisting { get; }
    }
}
