using System.Collections.Generic;
using UsersAndAwardsEntities;

namespace AbstractBll
{
    public interface IUsersLogic
    {
        string AddUser(User user);
        string DeleteUser(int iDUser);
        List<User> GetUsers();
        string AddAwardForUser(int idUser, int idAward);
    }
}