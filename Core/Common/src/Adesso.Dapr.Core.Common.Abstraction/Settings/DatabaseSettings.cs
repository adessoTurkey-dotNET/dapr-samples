namespace Adesso.Dapr.Core.Common.Abstraction.Settings
{
    public enum DatabaseType
    {
        SqlLite,
        MsSQL,
        Oracle,
        MySQL,
        PostgreSQL,
        Mongo,
        BigQuery
    }

    public sealed class DatabaseSettings : Dictionary<string, DatabaseSetting>
    {

    }

    public sealed class DatabaseSetting
    {
        public DatabaseType Type { get; set; }
        public string ConnectionString { get; set; }
        public string SchemaName { get; set; }
        public int Priority { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
    }
}
