using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Entities
{
    [Table("Loans")]
    public class Loan
    {
        public int Id { get; set; }
        public Friend Friend { get; set; }
        public Game Game { get; set; }
        public DateTime? LendAt { get; set; }
        public DateTime? RetrievedAt { get; set; }

        public Loan()
        {
        }

        public Loan(int id, Friend friend, Game game, DateTime lendAt, DateTime retrievedAt)
        {
            Id = id;
            Friend = friend;
            Game = game;
            LendAt = lendAt;
            RetrievedAt = retrievedAt;
        }
    }
}