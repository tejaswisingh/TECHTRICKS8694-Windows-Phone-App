// ------------------------------------------------------------------------
// ========================================================================
// THIS CODE AND INFORMATION ARE GENERATED BY AUTOMATIC CODE GENERATOR
// ========================================================================
// Template:   	AboutViewModel.tt
// Version:		2.0
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ViewModelsBase = WPAppStudio.ViewModel.Base;
using WPAppStudio;
using WPAppStudio.Entities.Base;
using WPAppStudio.Services.Interfaces;
using WPAppStudio.ViewModel.Base;
using WPAppStudio.ViewModel.Interfaces;

namespace WPAppStudio.ViewModel
{
    /// <summary>
    /// Implementation of About ViewModel.
    /// </summary>
    public partial class AboutViewModel : ViewModelsBase.VMBase, IAboutViewModel
    {       
		private string _title;
		private string _description;
		private string _version;
		private string _appLink;
		private readonly INavigationService _navigationService;
		private readonly IShareService _shareService;
		
		public string Title 
		{ 
			get 
			{ 
				return _title; 
			} 
			set
			{
				SetProperty(ref _title, value);
			}			
		}
		
		public string Description 
		{ 
			get 
			{ 
				return _description; 
			} 
			set
			{
				SetProperty(ref _description, value);
			}			
		}

		public string Version 
		{ 
			get 
			{ 
				return _version; 
			} 
			set
			{
				SetProperty(ref _version, value);
			}			
		}

		public string AppLink
        {
            get
            {
                return _appLink;
            }
            set
            {
                SetProperty(ref _appLink, value);
            }
        }
				
        /// <summary>
        /// Initializes a new instance of the <see cref="AboutViewModel" /> class.
        /// </summary>
        public AboutViewModel(INavigationService navigationService, IShareService shareService)
        {
			_title = @"TECHTRICKS8694";
			_description = @"Its a app for the technical blog TECHTRICKS8694 , you fill all the articles of the blog presented to you right here on your phone without having any need to open browser and going to the website , you find amazing content here , all the technical news and"; 
			_version = "v1";
			_appLink = "https://apps.windowsstore.com/DashBoard/DownloadAppXap?appId=209681c2-4573-4b2a-809a-474fab0ee821";
			_navigationService = navigationService;
			_shareService = shareService;
        }
		
		private ICommand _licenseCommand;

        /// <summary>
        /// Gets the LicenseCommand command.
        /// </summary>
        public ICommand LicenseCommand
        {
            get { return _licenseCommand = _licenseCommand ?? new DelegateCommand(LicenseCommandDelegate); }
        }

        public void LicenseCommandDelegate()
        {
            _navigationService.NavigateTo<ILicenseViewModel>();
        }

		/// <summary>
        /// Delegate method for the ShareAppCommand command.
        /// </summary>
        public void ShareAppCommandDelegate()
        {
            if (_shareService.AppExistInMarketPlace())
            {
                AppLink = Windows.ApplicationModel.Store.CurrentApp.LinkUri.AbsoluteUri;
            }
            _shareService.Share(Title, Description, AppLink);
        }

        private ICommand _shareAppCommand;

        /// <summary>
        /// Gets the ShareAppCommand command.
        /// </summary>
        public ICommand ShareAppCommand
        {
            get { return _shareAppCommand = _shareAppCommand ?? new DelegateCommand(ShareAppCommandDelegate); }
        }
    }
}
