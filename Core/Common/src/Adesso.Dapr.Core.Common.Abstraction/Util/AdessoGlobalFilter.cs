namespace Adesso.Dapr.Core.Common.Abstraction.Util
{
    public class AdessoGlobalFilter
    {
        public AdessoGlobalFilter(
            string name,
            AdessoGlobalFilterExpressionType type,
            AdessoGlobalFilterOperationType operationType,
            object value)
        {
            this.Type = type;
            this.Name = name;
            this.OperationType = operationType;
            this.Value = value;
        }
        public string Name { get; set; }

        public AdessoGlobalFilterExpressionType Type { get; set; }

        public AdessoGlobalFilterOperationType OperationType { get; set; }

        public object Value { get; set; }
    }
}
