using System;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Usecases.Game
{
    public class LoanOutput
    {
        public int Id { get; set; }
        public string Game { get; set; }
        public string Friend { get; set; }
        public DateTime? LendAt { get; set; }
        public DateTime? RetrievedAt { get; set; }

        public LoanOutput()
        {
        }

        public LoanOutput(int id, string game, string friend, DateTime? lendAt, DateTime? retrievedAt)
        {
            Id = id;
            Game = game;
            Friend = friend;
            LendAt = lendAt;
            RetrievedAt = retrievedAt;
        }
    }
}