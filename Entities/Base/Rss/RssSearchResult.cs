using System;
using System.Linq;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace WPAppStudio.Entities.Base
{
    /// <summary>
    /// Representation of the results in a RSS search.
    /// </summary>
    public class RssSearchResult : BindableBase
    {
        private string _author;
        /// <summary>
        /// Gets/Sets the author of the RSS.
        /// </summary>
        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                SetProperty(ref _author, value);
            }
        }

        private DateTime _publishDate;
        /// <summary>
        /// Gets/Sets the publish date of the RSS.
        /// </summary>
        public DateTime PublishDate
        {
            get
            { return _publishDate; }
            set
            {
                SetProperty(ref _publishDate, value);
            }
        }

        private string _id;
        /// <summary>
        /// Gets/Sets the identifier of the RSS.
        /// </summary>
        public string Id
        {
            get { return _id; }
            set
            {
                SetProperty(ref _id, value);
            }
        }

        private string _title;
        /// <summary>
        /// Gets/Sets the title of the RSS.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        private string _summary;
        /// <summary>
        /// Gets/Sets the summary of the RSS.
        /// </summary>
        public string Summary
        {
            get { return _summary; }
            set
            {
                SetProperty(ref _summary, value);
            }
        }

        private string _content;
        /// <summary>
        /// Gets/Sets the summary of the RSS.
        /// </summary>
        public string Content
        {
            get { return _content; }
            set
            {
                SetProperty(ref _content, value);
            }
        }

        private string _imageUrl;
        /// <summary>
        /// Gets/Sets the image URL of the RSS.
        /// </summary>
        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                SetProperty(ref _imageUrl, value);
            }
        }
		
        private string _extraImageUrl;
        /// <summary>
        /// Gets/Sets the extra image URL of the RSS.
        /// </summary>
        public string ExtraImageUrl
        {
            get { return _extraImageUrl; }
            set
            {
                SetProperty(ref _extraImageUrl, value);
            }
        }

        private string _mediaUrl;
        /// <summary>
        /// Gets/Sets the video URL of the RSS.
        /// </summary>
        public string MediaUrl
        {
            get { return _mediaUrl; }
            set
            {
                SetProperty(ref _mediaUrl, value);
            }
        }

        private string _feedUrl;
        /// <summary>
        /// Gets/Sets the RSS item feed URL.
        /// </summary>
        public string FeedUrl
        {
            get { return _feedUrl; }
            set
            {
                SetProperty(ref _feedUrl, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="RssSearchResult" /> class.
        /// </summary>
        public RssSearchResult() { }

		/// <summary>
        /// Initializes a new instance of <see cref="RssSearchResult" /> class.
        /// </summary>
        /// <param name="item">A valid SyndicationItem.</param>
        /// <param name="feedImage">Source feed image</param>
        public RssSearchResult(SyndicationItem item, string feedImage)
            : this()
        {
            Author = item.Authors.Count > 0 ? item.Authors[0].Name : string.Empty;	

			if (string.IsNullOrEmpty(Author))
            {
                if (item.ElementExtensions.Count(p => p.OuterName == "creator") != 0)
                {
                    var creator = item.ElementExtensions.FirstOrDefault(p => p.OuterName == "creator");
                    if (creator != null)
                        Author = creator.GetObject<XElement>().Value;
                }
            }
			
            Id = item.Id;
            Title = item.Title != null ? HttpUtility.HtmlDecode(item.Title.Text) : string.Empty;
            Content = HttpUtility.HtmlDecode(RssUtil.SanitizeHtml(RssUtil.GetSummary(item)));
			Summary = RssUtil.SanitizeHtml(string.IsNullOrEmpty(Content) ? string.Empty : Content);
		    if (Summary.Length > 140)
		        Summary = HtmlUtil.TruncateHtml(Summary, 137, "...");
            PublishDate = item.PublishDate.DateTime;
            ImageUrl = RssUtil.GetImage(item, true);
			ExtraImageUrl = RssUtil.GetExtraImage(item);
            if (string.IsNullOrEmpty(ImageUrl) && !string.IsNullOrEmpty(ExtraImageUrl))
                ImageUrl = ExtraImageUrl;
		    if (string.IsNullOrEmpty(ImageUrl))
                ImageUrl = feedImage;
				
			if (String.IsNullOrEmpty(ImageUrl))
            {
                var encoded = item.ElementExtensions.FirstOrDefault(p => p.OuterName == "encoded");
                string encodedText = string.Empty;

                if (encoded != null)
                    encodedText = encoded.GetObject<XElement>().Value;

                var imageUrl =
                    Regex.Match(encodedText, "<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase).Groups[1].Value;
                ImageUrl = !string.IsNullOrEmpty(imageUrl) ? imageUrl : string.Empty;
            }
			
			MediaUrl = RssUtil.GetMediaVideoURL(item);
			FeedUrl = RssUtil.GetItemFeedLink(item);
        }
		
		public override bool Equals(object obj)
		{
			var cmp = obj as RssSearchResult;
			
			if(cmp == null) return false;

		    if (Title != null)
		        return Title.Equals(cmp.Title);
		    if (Id != null)
		        return Id.Equals(cmp.Id);
		    return this==obj;
		}

		public override int GetHashCode()
		{
            if (Title != null)
                return Title.GetHashCode();
            if (Id != null)
                return Id.GetHashCode();
		    return base.GetHashCode();
		}
    }
}
