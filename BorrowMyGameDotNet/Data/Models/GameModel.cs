using System.ComponentModel.DataAnnotations.Schema;

namespace BorrowMyGameDotNet.Data.Models
{
    [Table("Game")]
    public class GameModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsBorrowed { get; set; }
    }
}