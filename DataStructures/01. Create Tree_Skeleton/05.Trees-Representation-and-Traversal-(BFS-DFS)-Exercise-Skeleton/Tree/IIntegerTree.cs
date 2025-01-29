using System;
using System.Collections.Generic;

namespace Tree
{
    public interface IIntegerTree: IAbstractTree<int>
    {
        List<List<int>> GetPathsWithGivenSum(int sum);

        List<List<int>> GetSubtreesWithGivenSum(int sum);
    }
}
