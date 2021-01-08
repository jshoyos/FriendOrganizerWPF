using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IFriendLookupDataService _friendLookupDataService;
        private readonly IEventAggregator _ea;

        public NavigationViewModel(IFriendLookupDataService friendLookupDataService, IEventAggregator ea)
        {
            _friendLookupDataService = friendLookupDataService;
            _ea = ea;
            Friends = new ObservableCollection<NavigationItemViewModel>();
            _ea.GetEvent<UpdatedFriendEvent>().Subscribe(AfterFriendSaved);
        }

        private void AfterFriendSaved(UpdatedFriendEventArgs args)
        {
            var lookupItem = Friends.Single(l => l.Id == args.Id);
            lookupItem.DisplayMember = args.DisplayMember;
        }

        public async Task LoadAsync()
        {
            var lookup = await _friendLookupDataService.GetFriendLookupAsync();
            Friends.Clear();
            foreach (var item in lookup)
            {
                Friends.Add(new NavigationItemViewModel(item.Id, item.DisplayMember));
            }
        }
        public ObservableCollection<NavigationItemViewModel> Friends { get; set; }

        private NavigationItemViewModel _selectedFriend;

        public NavigationItemViewModel SelectedFriend
        {
            get { return _selectedFriend; }
            set {
                _selectedFriend = value;
                OnPropertyChanged();
                if (_selectedFriend != null)
                {
                    _ea.GetEvent<OpenFriendDetailViewEvent>().Publish(_selectedFriend.Id);
                }
            }
        }

    }
}
