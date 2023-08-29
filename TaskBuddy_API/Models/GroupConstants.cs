namespace TaskBuddy_API.Models
{
    public class GroupConstants
    {
        public static List<GroupModel> Groups = new List<GroupModel>()
        {
            new GroupModel()
            {
                Id = "G-00000000000000000000000000000000",
                Name = "Living Room",
                TaskIds = new List<string>
                {
                    "T-00000000000000000000000000000000",
                },
                UserIds = new List<string>
                {
                    "000000000000000000000",
                },
            },
        };
    }
}