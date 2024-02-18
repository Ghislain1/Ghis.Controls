namespace Ghis.Controls.Test.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

internal class ManualUI : TestCategoryBaseAttribute
{
    public override IList<string> TestCategories => new[] { nameof(ManualUI) }.ToList();

}