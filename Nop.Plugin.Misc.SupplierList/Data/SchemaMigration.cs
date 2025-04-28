using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Misc.SupplierList.Domain;

namespace Nop.Plugin.Misc.SupplierList.Data;

[NopMigration("2024/04/19 12:00:00", "Misc.SupplierList base schema", MigrationProcessType.Installation)]
public class SchemaMigration : AutoReversingMigration
{
    #region Methods

    /// <summary>
    /// Collect the UP migration expressions
    /// </summary>
    public override void Up()
    {
        Create.TableFor<Supplier>();
    }

    #endregion
} 