using System;
using System.Collections.Generic;
using System.Linq;

public class SortingTypeSelector : FilterSelector<RepositoryCard>
{
    private Func<RepositoryCard, object> _GetKeySelector()
    {
        switch (Value)
        {
            case 0:
                {
                    return x => x.Repository.Name;
                }
            case 1:
                {
                    return x => x.Repository.UpdatedAt;
                }
            default:
                {
                    return x => x;
                }
        }
    }

    public override IEnumerable<RepositoryCard> ApplyFilter(IEnumerable<RepositoryCard> collection)
    {
        Func<RepositoryCard, object> keySelector = _GetKeySelector();
        return collection.OrderBy(keySelector);
    }
}
