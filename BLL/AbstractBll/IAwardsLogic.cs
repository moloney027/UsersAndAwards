using System.Collections.Generic;
using UsersAndAwardsEntities;

namespace AbstractBll
{
    public interface IAwardsLogic
    {
        string AddAward(Award award);
        List<Award> GetAwards();
    }
}