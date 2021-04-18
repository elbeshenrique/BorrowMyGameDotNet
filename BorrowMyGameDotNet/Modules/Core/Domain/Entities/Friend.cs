using System.ComponentModel.DataAnnotations.Schema;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Entities
{
    [Table("Friends")]
    public class Friend
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Friend()
        {
        }

        public Friend(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}