using System.Collections.Generic;
using UsersAndAwardsEntities;

namespace AbstractDal
{
    public interface IAwardsDao
    {
        int AddAward(Award award);
        List<Award> GetAwards();
    }
}