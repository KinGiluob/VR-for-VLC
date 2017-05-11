﻿using VLC.Model.Music;
using VLC.ViewModels;
using VLC.Model;
using VLC.Utils;
using VLC.Helpers;

namespace VLC.Commands.MusicPlayer
{
    public class PlayArtistAlbumsCommand: AlwaysExecutableCommand
    {
        public override async void Execute(object parameter)
        {
            if (parameter is ArtistItem)
            {
                Locator.NavigationService.GoOnPlaybackStarted(VLCPage.MusicPlayerPage);
                var artist = parameter as ArtistItem;
                var tracks = Locator.MediaLibrary.LoadTracksByArtistId(artist.Id).ToObservable();

                await Locator.PlaybackService.SetPlaylist(tracks);
            }
        }
    }
}