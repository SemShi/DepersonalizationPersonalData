using FluentMigrator.Runner.VersionTableInfo;

namespace DbMigrator
{
    public class VersionTableMetaData : IVersionTableMetaData
    {
        public object ApplicationContext { get; set; } = default!;
        public bool OwnsSchema => true;
        public string SchemaName => "public";
        public string TableName => "bd_versions";
        public string ColumnName => "v";
        public string DescriptionColumnName => "description";
        public string UniqueIndexName => "IX_ver";
        public string AppliedOnColumnName => "applied_on";
    }
}