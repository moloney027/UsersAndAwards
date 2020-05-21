using System.Collections.Generic;
using AbstractBll;
using UsersAndAwardsDAL;
using UsersAndAwardsEntities;

namespace UsersAndAwardsLogic
{
    public class AwardsLogic : IAwardsLogic
    {
        private readonly AwardsDao _awardsDao;

        public AwardsLogic()
        {
            _awardsDao = new AwardsDao();
        }
        
        public string AddAward(Award award)
        {
            var  number = _awardsDao.AddAward(award);
            return number > 0 ? $"Добавление успешно" : $"Ошибка при добавлении награды";
        }

        public List<Award> GetAwards()
        {
            var listAwards = _awardsDao.GetAwards();
            return listAwards;
        }
    }
}