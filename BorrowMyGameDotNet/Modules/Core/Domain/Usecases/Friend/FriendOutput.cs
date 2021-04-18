namespace BorrowMyGameDotNet.Modules.Core.Domain.Usecases.Friend
{
    public class FriendOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public FriendOutput()
        {
        }

        public FriendOutput(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}