// ------------------------------------------------------------------------
// ========================================================================
// THIS CODE AND INFORMATION ARE GENERATED BY AUTOMATIC CODE GENERATOR
// ========================================================================
// Template:   	ViewModel.tt
// Version:		2.0
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Controls = WPAppStudio.Controls;
using Entities = WPAppStudio.Entities;
using EntitiesBase = WPAppStudio.Entities.Base;
using IServices = WPAppStudio.Services.Interfaces;
using IViewModels = WPAppStudio.ViewModel.Interfaces;
using Localization = WPAppStudio.Localization;
using Repositories = WPAppStudio.Repositories;
using Services = WPAppStudio.Services;
using ViewModelsBase = WPAppStudio.ViewModel.Base;
using WPAppStudio;
using WPAppStudio.Shared;

namespace WPAppStudio.ViewModel
{
    /// <summary>
    /// Implementation of BLOGPOSTS_Detail ViewModel.
    /// </summary>
    [CompilerGenerated]
    [GeneratedCode("Radarc", "4.0")]
    public partial class BLOGPOSTS_DetailViewModel : ViewModelsBase.VMBase, IViewModels.IBLOGPOSTS_DetailViewModel, ViewModelsBase.INavigable
    {       

		private readonly Repositories.BLOGPOSTS_rssfeed _bLOGPOSTS_rssfeed;
		private readonly IServices.IDialogService _dialogService;
		private readonly IServices.INavigationService _navigationService;
		private readonly IServices.ISpeechService _speechService;
		private readonly IServices.IShareService _shareService;
		private readonly IServices.ILiveTileService _liveTileService;
		
        /// <summary>
        /// Initializes a new instance of the <see cref="BLOGPOSTS_DetailViewModel" /> class.
        /// </summary>
        /// <param name="bLOGPOSTS_rssfeed">The B L O G P O S T S_rssfeed.</param>
        /// <param name="dialogService">The Dialog Service.</param>
        /// <param name="navigationService">The Navigation Service.</param>
        /// <param name="speechService">The Speech Service.</param>
        /// <param name="shareService">The Share Service.</param>
        /// <param name="liveTileService">The Live Tile Service.</param>
        public BLOGPOSTS_DetailViewModel(Repositories.BLOGPOSTS_rssfeed bLOGPOSTS_rssfeed, IServices.IDialogService dialogService, IServices.INavigationService navigationService, IServices.ISpeechService speechService, IServices.IShareService shareService, IServices.ILiveTileService liveTileService)
        {
			_bLOGPOSTS_rssfeed = bLOGPOSTS_rssfeed;
			_dialogService = dialogService;
			_navigationService = navigationService;
			_speechService = speechService;
			_shareService = shareService;
			_liveTileService = liveTileService;
        }
		
	
		private EntitiesBase.RssSearchResult _currentRssSearchResult;

        /// <summary>
        /// CurrentRssSearchResult property.
        /// </summary>		
        public EntitiesBase.RssSearchResult CurrentRssSearchResult
        {
            get
            {
				return _currentRssSearchResult;
            }
            set
            {
                SetProperty(ref _currentRssSearchResult, value);
            }
        }
	
		private bool _hasNextpanoramaBLOGPOSTS_Detail0;

        /// <summary>
        /// HasNextpanoramaBLOGPOSTS_Detail0 property.
        /// </summary>		
        public bool HasNextpanoramaBLOGPOSTS_Detail0
        {
            get
            {
				return _hasNextpanoramaBLOGPOSTS_Detail0;
            }
            set
            {
                SetProperty(ref _hasNextpanoramaBLOGPOSTS_Detail0, value);
            }
        }
	
		private bool _hasPreviouspanoramaBLOGPOSTS_Detail0;

        /// <summary>
        /// HasPreviouspanoramaBLOGPOSTS_Detail0 property.
        /// </summary>		
        public bool HasPreviouspanoramaBLOGPOSTS_Detail0
        {
            get
            {
				return _hasPreviouspanoramaBLOGPOSTS_Detail0;
            }
            set
            {
                SetProperty(ref _hasPreviouspanoramaBLOGPOSTS_Detail0, value);
            }
        }

        /// <summary>
        /// Delegate method for the TextToSpeechBLOGPOSTS_DetailStaticControlCommand command.
        /// </summary>
        public  void TextToSpeechBLOGPOSTS_DetailStaticControlCommandDelegate() 
        {
				_speechService.TextToSpeech(CurrentRssSearchResult.Title);
        }
		

        private ICommand _textToSpeechBLOGPOSTS_DetailStaticControlCommand;

        /// <summary>
        /// Gets the TextToSpeechBLOGPOSTS_DetailStaticControlCommand command.
        /// </summary>
        public ICommand TextToSpeechBLOGPOSTS_DetailStaticControlCommand
        {
            get { return _textToSpeechBLOGPOSTS_DetailStaticControlCommand = _textToSpeechBLOGPOSTS_DetailStaticControlCommand ?? new ViewModelsBase.DelegateCommand(TextToSpeechBLOGPOSTS_DetailStaticControlCommandDelegate); }
        }

        /// <summary>
        /// Delegate method for the ShareBLOGPOSTS_DetailStaticControlCommand command.
        /// </summary>
        public  void ShareBLOGPOSTS_DetailStaticControlCommandDelegate() 
        {
				_shareService.Share(CurrentRssSearchResult.Title, "", CurrentRssSearchResult.FeedUrl, CurrentRssSearchResult.ImageUrl);
        }
		

        private ICommand _shareBLOGPOSTS_DetailStaticControlCommand;

        /// <summary>
        /// Gets the ShareBLOGPOSTS_DetailStaticControlCommand command.
        /// </summary>
        public ICommand ShareBLOGPOSTS_DetailStaticControlCommand
        {
            get { return _shareBLOGPOSTS_DetailStaticControlCommand = _shareBLOGPOSTS_DetailStaticControlCommand ?? new ViewModelsBase.DelegateCommand(ShareBLOGPOSTS_DetailStaticControlCommandDelegate); }
        }

        /// <summary>
        /// Delegate method for the PinToStartBLOGPOSTS_DetailStaticControlCommand command.
        /// </summary>
        public  void PinToStartBLOGPOSTS_DetailStaticControlCommandDelegate() 
        {
				_liveTileService.PinToStart(typeof(IViewModels.IBLOGPOSTS_DetailViewModel), CreateTileInfoBLOGPOSTS_DetailStaticControl());
        }
		

        private ICommand _pinToStartBLOGPOSTS_DetailStaticControlCommand;

        /// <summary>
        /// Gets the PinToStartBLOGPOSTS_DetailStaticControlCommand command.
        /// </summary>
        public ICommand PinToStartBLOGPOSTS_DetailStaticControlCommand
        {
            get { return _pinToStartBLOGPOSTS_DetailStaticControlCommand = _pinToStartBLOGPOSTS_DetailStaticControlCommand ?? new ViewModelsBase.DelegateCommand(PinToStartBLOGPOSTS_DetailStaticControlCommandDelegate); }
        }

        /// <summary>
        /// Delegate method for the GoToSourceBLOGPOSTS_DetailStaticControlCommand command.
        /// </summary>
        public  void GoToSourceBLOGPOSTS_DetailStaticControlCommandDelegate() 
        {
				_navigationService.NavigateTo(string.IsNullOrEmpty(CurrentRssSearchResult.FeedUrl) ? null : new Uri(CurrentRssSearchResult.FeedUrl));
        }
		

        private ICommand _goToSourceBLOGPOSTS_DetailStaticControlCommand;

        /// <summary>
        /// Gets the GoToSourceBLOGPOSTS_DetailStaticControlCommand command.
        /// </summary>
        public ICommand GoToSourceBLOGPOSTS_DetailStaticControlCommand
        {
            get { return _goToSourceBLOGPOSTS_DetailStaticControlCommand = _goToSourceBLOGPOSTS_DetailStaticControlCommand ?? new ViewModelsBase.DelegateCommand(GoToSourceBLOGPOSTS_DetailStaticControlCommandDelegate); }
        }

        /// <summary>
        /// Delegate method for the NextpanoramaBLOGPOSTS_Detail0 command.
        /// </summary>
        public async void NextpanoramaBLOGPOSTS_Detail0Delegate() 
        {
				LoadingCurrentRssSearchResult = true;
			var next = await  _bLOGPOSTS_rssfeed.Next(CurrentRssSearchResult);

			if(next != null)
				CurrentRssSearchResult = next;

			RefreshHasPrevNext();
        }
		
		
        private bool _loadingCurrentRssSearchResult;
		
        public bool LoadingCurrentRssSearchResult
        {
            get { return _loadingCurrentRssSearchResult; }
            set { SetProperty(ref _loadingCurrentRssSearchResult, value); }
        }

        private ICommand _nextpanoramaBLOGPOSTS_Detail0;

        /// <summary>
        /// Gets the NextpanoramaBLOGPOSTS_Detail0 command.
        /// </summary>
        public ICommand NextpanoramaBLOGPOSTS_Detail0
        {
            get { return _nextpanoramaBLOGPOSTS_Detail0 = _nextpanoramaBLOGPOSTS_Detail0 ?? new ViewModelsBase.DelegateCommand(NextpanoramaBLOGPOSTS_Detail0Delegate); }
        }

        /// <summary>
        /// Delegate method for the PreviouspanoramaBLOGPOSTS_Detail0 command.
        /// </summary>
        public async void PreviouspanoramaBLOGPOSTS_Detail0Delegate() 
        {
				LoadingCurrentRssSearchResult = true;
			var prev = await  _bLOGPOSTS_rssfeed.Previous(CurrentRssSearchResult);

			if(prev != null)
				CurrentRssSearchResult = prev;

			RefreshHasPrevNext();
        }
		

        private ICommand _previouspanoramaBLOGPOSTS_Detail0;

        /// <summary>
        /// Gets the PreviouspanoramaBLOGPOSTS_Detail0 command.
        /// </summary>
        public ICommand PreviouspanoramaBLOGPOSTS_Detail0
        {
            get { return _previouspanoramaBLOGPOSTS_Detail0 = _previouspanoramaBLOGPOSTS_Detail0 ?? new ViewModelsBase.DelegateCommand(PreviouspanoramaBLOGPOSTS_Detail0Delegate); }
        }

        private async void RefreshHasPrevNext()
        {
            HasPreviouspanoramaBLOGPOSTS_Detail0 = await _bLOGPOSTS_rssfeed.HasPrevious(CurrentRssSearchResult);
			HasNextpanoramaBLOGPOSTS_Detail0 = await _bLOGPOSTS_rssfeed.HasNext(CurrentRssSearchResult);
			LoadingCurrentRssSearchResult = false;
		}
		public object NavigationContext
        {
            set
            {              
                if (!(value is EntitiesBase.RssSearchResult)) { return; }
                
                CurrentRssSearchResult = value as EntitiesBase.RssSearchResult;
                RefreshHasPrevNext();
            }
        }
        /// <summary>
        /// Initializes a <see cref="Services.TileInfo" /> object for the BLOGPOSTS_DetailStaticControl control.
        /// </summary>
		/// <returns>A <see cref="Services.TileInfo" /> object.</returns>
        public Services.TileInfo CreateTileInfoBLOGPOSTS_DetailStaticControl()
        {
            var tileInfo = new Services.TileInfo
            {
                CurrentId = CurrentRssSearchResult.Title,
                Title = CurrentRssSearchResult.Title,
                BackTitle = CurrentRssSearchResult.Title,
                BackContent = string.Empty,
                Count = 0,
                BackgroundImagePath = CurrentRssSearchResult.ImageUrl,
                BackBackgroundImagePath = CurrentRssSearchResult.ImageUrl,
                LogoPath = "Logo-1ea99746-061b-4dec-a7fe-1eee87957505.png"
            };
            return tileInfo;
        }
    }
}