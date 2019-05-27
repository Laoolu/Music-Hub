using System.Collections.Generic;
using MusicHub.Models;

namespace MusicHub.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public bool ShowActions { get; set; }
    }
}