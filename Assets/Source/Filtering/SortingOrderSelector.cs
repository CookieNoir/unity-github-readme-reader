using System.Collections.Generic;
using System.Linq;

public class SortingOrderSelector : FilterSelector<RepositoryCard>
{
    public override IEnumerable<RepositoryCard> ApplyFilter(IEnumerable<RepositoryCard> collection)
    {
        if (Value > 0) return collection;
        else return collection.Reverse();
    }
}
