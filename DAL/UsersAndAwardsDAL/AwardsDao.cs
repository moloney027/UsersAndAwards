using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AbstractDal;
using UsersAndAwardsEntities;
using Utils;

namespace UsersAndAwardsDAL
{
    public class AwardsDao: IAwardsDao
    {
        
        private readonly DbUtils _dbUtils;

        public AwardsDao()
        {
            const string datasource = @"127.0.0.1";
            const string database = "UsersAndAwards";
            _dbUtils = new DbUtils(datasource, database);
        }
        
        public int AddAward(Award award)
        {
            string sqlExpression = "INSERT INTO Awards (Title) VALUES (@Title)";
            using var connection = _dbUtils.GetDbConnection();
            connection.Open();
            using var cmd = new SqlCommand(sqlExpression, connection);
            var titleParam = new SqlParameter {ParameterName = "@Title", Value = award.Title};
            cmd.Parameters.Add(titleParam);
            return cmd.ExecuteNonQuery();
        }
        
        private List<User> GetUsersForAward(int awardId)
        {
            var users = new List<User>();
            const string sqlExpression = 
                "SELECT Users.ID, Users.Name, Users.DateOfBirth, Users.Age, UsersID, AwardsID FROM Users join UsersAndAwards_ UAA on Users.ID = UAA.UsersID join Awards on Awards.ID = UAA.AwardsID where UAA.AwardsID=@id";
            using var connection = _dbUtils.GetDbConnection();
            connection.Open();
            using var cmd = new SqlCommand(sqlExpression, connection);
            cmd.Parameters.AddWithValue("@id", awardId);
            using var dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                var us = new User((int) dataReader["ID"], (string) (dataReader["Name"]),
                    (DateTime) (dataReader["DateOfBirth"]),
                    (int) (dataReader["Age"]));
                users.Add(us);
            }
            return users;
        }

        public List<Award> GetAwards()
        {
            var awards = new List<Award>();
            const string sqlExpression = "SELECT ID, Title FROM Awards";
            using var connection = _dbUtils.GetDbConnection();
            connection.Open();
            using var cmd = new SqlCommand(sqlExpression, connection);
            using var dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                var aw = new Award((int) (dataReader["ID"]), (string) (dataReader["Title"])) {Users = GetUsersForAward((int) dataReader["ID"])};
                awards.Add(aw);
            }
            return awards;
        }
    }
}