namespace Adesso.Dapr.Core.Common.Abstraction.Data.AutoSetters
{
    public sealed class AdessoCreationDefinition
    {
        public AdessoCreationDefinition()
        {
        }


        public AdessoCreationDefinition(
            AdessoCreationDefinitionItem createdOn,
            AdessoCreationDefinitionItem createdBy)
        {
            this.CreatedOn = createdOn;
            this.CreatedBy = createdBy;
        }

        public AdessoCreationDefinitionItem CreatedOn { get; init; }
        public AdessoCreationDefinitionItem CreatedBy { get; init; }
    }

    public sealed class AdessoCreationDefinitionItem
    {
        public AdessoCreationDefinitionItem(
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
