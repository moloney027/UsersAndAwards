using System.Collections.Generic;
using UsersAndAwardsEntities;

namespace AbstractDal
{
    public interface IUsersDao
    {
        int AddUser(User user);
        int DeleteUser(int iDUser);
        List<User> GetUsers();
        int AddAwardForUser(int idUser, int idAward);
    }
}