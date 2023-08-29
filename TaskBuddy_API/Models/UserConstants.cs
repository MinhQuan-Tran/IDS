namespace TaskBuddy_API.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel()
            {
                Id = "U-00000000000000000000000000000000",
                GoogleUserId = "000000000000000000000",
                Email = "Test@test.com",
                UserName = "Test"
            },
            new UserModel()
            {
                Id = "U-99999999999999999999999999999999",
                Password = "Test",
                Email = "Test@test.com",
                UserName = "Test"
            },
        };
    }
}
