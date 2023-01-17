using System.Linq;
using System.Collections.Generic;

public class ReadmeFilterSelector : FilterSelector<RepositoryCard>
{
    public override IEnumerable<RepositoryCard> ApplyFilter(IEnumerable<RepositoryCard> collection)
    {
        bool showOnlyWithReadme = Value > 0;
        if (showOnlyWithReadme) return collection.Where(x => x.HasReadme);
        else return collection;
    }
}
