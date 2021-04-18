using System.Collections.Generic;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using BorrowMyGameDotNet.Modules.Core.Domain.Presenters;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases.Friend;

namespace BorrowMyGameDotNet.Modules.Core.Application.Presenters
{
    public class FriendPresenter : IFriendPresenter
    {

        public FriendOutput ToOutput(Friend friend)
        {
            return new FriendOutput
            {
                Id = friend.Id,
                Name = friend.Name
            };
        }

        public IEnumerable<FriendOutput> ToOutputs(IEnumerable<Friend> friends)
        {
            var friendOutputs = new List<FriendOutput>();

            foreach (var friend in friends)
            {
                var friendOutput = ToOutput(friend);
                friendOutputs.Add(friendOutput);
            }

            return friendOutputs;
        }
    }
}