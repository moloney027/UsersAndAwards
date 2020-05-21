
using System.Collections.Generic;
using System.Linq;
using AbstractBll;
using UsersAndAwardsDAL;
using UsersAndAwardsEntities;

namespace UsersAndAwardsLogic
{
    public class UsersLogic : IUsersLogic
    {
        public UsersDao _usersDao;

        public UsersLogic()
        {
            _usersDao = new UsersDao();
        }

        public string AddUser(User user)
        {
            var  number = _usersDao.AddUser(user);
            return number > 0 ? $"Добавление успешно" : $"Ошибка при добавлении пользователя";
        }

        public string DeleteUser(int iDUser)
        {
            var number = _usersDao.DeleteUser(iDUser);
            return number > 0 ? $"Удаление успешно" : $"Ошибка при удалении пользователя";
        }

        public List<User> GetUsers()
        {
            var listUsers = _usersDao.GetUsers();
            return listUsers;
        }

        public string AddAwardForUser(int idUser, int idAward)
        {
            var  number = _usersDao.AddAwardForUser(idUser, idAward);
            return number > 0 ? $"Добавление успешно" : $"Ошибка при добавлении награды пользователю";
        }
    }
}