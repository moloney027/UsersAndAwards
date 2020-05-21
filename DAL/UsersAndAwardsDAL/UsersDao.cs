using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AbstractDal;
using UsersAndAwardsEntities;
using Utils;

namespace UsersAndAwardsDAL
{
    public class UsersDao : IUsersDao
    {
        private readonly DbUtils _dbUtils;

        public UsersDao()
        {
            const string datasource = @"127.0.0.1";
            const string database = "UsersAndAwards";
            _dbUtils = new DbUtils(datasource, database);
        }

        public int AddUser(User user)
        {
            const string sqlExpression =
                "INSERT INTO Users (Name, DateOfBirth, Age) VALUES (@Name, @DateOfBirth, @Age)";
            using var connection = _dbUtils.GetDbConnection();
            connection.Open();
            using var cmd = new SqlCommand(sqlExpression, connection);
            var nameParam = new SqlParameter {ParameterName = "@Name", Value = user.Name};
            cmd.Parameters.Add(nameParam);
            var dateParam = new SqlParameter {ParameterName = "@DateOfBirth", Value = user.DateOfBirth};
            cmd.Parameters.Add(dateParam);
            var ageParam = new SqlParameter {ParameterName = "@Age", Value = user.Age};
            cmd.Parameters.Add(ageParam);
            return cmd.ExecuteNonQuery();
        }

        public int DeleteUser(int iDUser)
        {
            const string sqlExpression = "DELETE FROM Users WHERE ID = @iD";
            using var connection = _dbUtils.GetDbConnection();
            connection.Open();
            using var cmd = new SqlCommand(sqlExpression, connection);
            var idParam = new SqlParameter {ParameterName = "@id", Value = iDUser};
            cmd.Parameters.Add(idParam);
            return cmd.ExecuteNonQuery();
        }

        private List<Award> GetAwardsForUser(int userId)
        {
            var awards = new List<Award>();
            const string sqlExpression =
                "SELECT Awards.ID, Awards.Title, UsersID, AwardsID FROM Awards join UsersAndAwards_ UAA on Awards.ID = UAA.AwardsID join Users on Users.ID = UAA.UsersID where UAA.UsersID=@id";
            using var connection = _dbUtils.GetDbConnection();
            connection.Open();
            using var cmd = new SqlCommand(sqlExpression, connection);
            var idParam = new SqlParameter {ParameterName = "@id", Value = userId};
            cmd.Parameters.Add(idParam);
            using var dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                var aw = new Award((int) dataReader["ID"], (string) (dataReader["Title"]));
                awards.Add(aw);
            }

            return awards;
        }

        public List<User> GetUsers()
        {
            var users = new List<User>();
            const string sqlExpression = "SELECT ID, Name, DateOfBirth, Age FROM Users";
            using (var connection = _dbUtils.GetDbConnection())
            {
                connection.Open();
                using var cmd = new SqlCommand(sqlExpression, connection);
                using var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    var u = new User((int) (dataReader["ID"]), (string) (dataReader["Name"]),
                        (DateTime) (dataReader["DateOfBirth"]),
                        (int) (dataReader["Age"]));
                    users.Add(u);
                }

                connection.Close();
            }

            foreach (var user in users)
            {
                user.Awards = GetAwardsForUser(user.ID);
            }
            return users;
        }

        public int AddAwardForUser(int iDUser, int idAward)
        {
            const string sqlExpression =
                "INSERT INTO UsersAndAwards_ (UsersID, AwardsID) VALUES (@UsersID, @AwardsID)";
            using var connection = _dbUtils.GetDbConnection();
            connection.Open();
            using var cmd = new SqlCommand(sqlExpression, connection);
            var idUsParam = new SqlParameter {ParameterName = "@UsersID", Value = iDUser};
            cmd.Parameters.Add(idUsParam);
            var idAwParam = new SqlParameter {ParameterName = "@AwardsID", Value = idAward};
            cmd.Parameters.Add(idAwParam);
            return cmd.ExecuteNonQuery();
        }
    }
}