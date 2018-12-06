using MatchmakingService.Helpers;
using MatchmakingService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestEnv
{
    public class MatchmakingTests
    {
        [Fact]
        public void MatchDuplicates()
        {
            var userOneGUID = Guid.NewGuid();
            var userTwoGUID = Guid.NewGuid();
            var userThreeGUID = Guid.NewGuid();
            var userFourGUID = Guid.NewGuid();
            var userFiveGUID = Guid.NewGuid();
            var userSixGUID = Guid.NewGuid();

            //Arrange
            UserMatch userOneMatch = new UserMatch()
            {
                User1Id = userOneGUID, //Guid.Parse("123abc12-123d-123k-124o-1234acvaq211"),
                User2Id = userTwoGUID, //Guid.Parse("123abd24-123d-123k-124o-1234acvaq211"),
                FirstSelection = false
            };
            UserInfo userOne = new UserInfo()
            {
                Id = 0,
                FirstName = "Mathias",
                Matches = new List<UserMatch>()
                {
                    userOneMatch
                }
            };

            UserMatch userTwoMatch = new UserMatch()
            {
                User1Id = userThreeGUID, //Guid.Parse("123abc12-123d-123k-124o-1234y8vaq211"),
                User2Id = userFourGUID, //Guid.Parse("123abc12-1hdd-123k-124o-1234acvaq211"),
                FirstSelection = true     
            };
            UserInfo userTwo = new UserInfo()
            {
                Id = 1,
                FirstName = "Rasmus",
                Matches = new List<UserMatch>()
                {
                    userTwoMatch
                }
            };

            UserMatch userThreeMatch = new UserMatch()
            {
                User1Id = userFiveGUID, //Guid.Parse("123abc12-123d-123k-124o-1234acsql211"),
                User2Id = userSixGUID, //Guid.Parse("123abc12-123d-123k-555o-1234acvaq211"),
                FirstSelection = true
            };
            UserInfo userThree = new UserInfo()
            {
                Id = 1,
                FirstName = "Hafsteinn",
                Matches = new List<UserMatch>()
                {
                    userThreeMatch
                }
            };
            List<UserInfo> users = new List<UserInfo>();
            users.Add(userOne);
            users.Add(userTwo);
            users.Add(userThree);


            
            List<UserMatch> usersMatch = new List<UserMatch>();
            usersMatch.Add(userOneMatch);
            usersMatch.Add(userTwoMatch);
            usersMatch.Add(userThreeMatch);

            //Act


            //Assert
            //Assert.Equal(2, MatchmakingHelpers.RemoveMatchDuplicates(users, usersMatch).Length);
        }
    }
}
