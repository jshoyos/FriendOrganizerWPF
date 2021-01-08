using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Event
{
    public class UpdatedFriendEvent : PubSubEvent<UpdatedFriendEventArgs>
    {
    }

    public class UpdatedFriendEventArgs
    {
        public int Id { get; set; }
        public string DisplayMember { get; set; }
    }
}
