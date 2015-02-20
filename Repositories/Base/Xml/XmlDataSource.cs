using System;
using System.Diagnostics;
using System.Net;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using WPAppStudio.Repositories.Resources;

namespace WPAppStudio.Repositories.Base
{
    /// <summary>
    /// Implementation of a data source based on XML.
    /// </summary>
    public class XmlDataSource : IXmlDataSource
    {
        /// <summary>
        /// Gets the XML data from a specified URL.
        /// </summary>
        /// <typeparam name="T">The generic type.</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>The data retrieved.</returns>
        public async Task<T> LoadRemote<T>(string url)
        {
            SyndicationFeed feed = (await LoadSyndicationFeed(url) ?? await LoadLinq(url)) ??
                                   await LoadRss10FeedFormatter(url);

            return (T)Convert.ChangeType(feed, typeof(T));
        }

		/// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns>SyndicationFeed</returns>
        private async Task<SyndicationFeed> LoadSyndicationFeed(string url)
        {
            SyndicationFeed feed;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                var response =
                    await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);

				using (var responseStream = response.GetResponseStream())
                {
                    var nt = new NameTable();
                    var nsmgr = new XmlNamespaceManager(nt);
                    nsmgr.AddNamespace("georss", "http://www.w3.org/2001/XMLSchema-instance");
                    var context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);
                    var xset = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };
                    var rdr = XmlReader.Create(responseStream, xset, context);

                    feed = SyndicationFeed.Load(rdr);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("{0} {1}, {2} {3}", AppResources.RssError, url, AppResources.Error, ex);
                feed = null;
            }

            return feed;
        }

		/// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns>SyndicationFeed</returns>
        private async Task<SyndicationFeed> LoadRss10FeedFormatter(string url)
        {
            SyndicationFeed feed;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                var response =
                    await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);

                using (var responseStream = response.GetResponseStream())
                {
                    var rss10Reader = new Rss10FeedFormatter();
                    var nt = new NameTable();
                    var nsmgr = new XmlNamespaceManager(nt);
                    nsmgr.AddNamespace("georss", "http://www.w3.org/2001/XMLSchema-instance");
                    var context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);
                    var xset = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };
                    var rdr = XmlReader.Create(responseStream, xset, context);
                    rss10Reader.ReadFrom(rdr);
                    feed = rss10Reader.Feed;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("{0} {1}, {2} {3}", AppResources.RssError, url, AppResources.Error, ex);
                feed = null;
            }

            return feed;
        }

		/// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns>SyndicationFeed</returns>
        private async Task<SyndicationFeed> LoadLinq(string url)
        {
            SyndicationFeed feed;

            try
            {
                XNamespace ns = "http://purl.org/rss/1.0/";

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                var response =
                    await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);

                using (var responseStream = response.GetResponseStream())
                {
                    string strContent;
                    using (var sr = new StreamReader(responseStream))
                    {
                        strContent = sr.ReadToEnd();
                    }
                    XDocument document = XDocument.Parse(strContent);

                    var items = (from item in document.Descendants(ns + "item")
                                 let xTitle = item.Element(ns + "title")
                                 where xTitle != null
                                 let xDescription = item.Element(ns + "description")
                                 where xDescription != null
                                 let xLink = item.Element(ns + "link")
                                 where xLink != null
                                 select new SyndicationItem
                                 {
									Id = xLink.Value,
                                    Title = new TextSyndicationContent(xTitle.Value),
                                    Summary = new TextSyndicationContent(xDescription.Value)
                                 }).ToList();

					if (items.Count == 0)
                    {
                        items = (from item in document.Descendants("item")
                                 let xTitle = item.Element("title")
                                 where xTitle != null
                                 let xDescription = item.Element("description")
                                 where xDescription != null
								 let xLink = item.Element("link")
                                 where xLink != null
                                 select new SyndicationItem
                                 {
									Id = xLink.Value,
                                     Title = new TextSyndicationContent(xTitle.Value),
                                     Summary = new TextSyndicationContent(xDescription.Value)
                                 }).ToList();
                    }
					
                    feed = new SyndicationFeed(items);
					
					if(!feed.Items.Any())
                        throw new Exception("No Data!");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("{0} {1}, {2} {3}", AppResources.RssError, url, AppResources.Error, ex);
                feed = null;
            }

            return feed;
        }
    }
}
