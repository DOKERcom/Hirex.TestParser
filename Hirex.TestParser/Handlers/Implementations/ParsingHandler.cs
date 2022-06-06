using Hirex.TestParser.BLL.Services.Interfaces;
using Hirex.TestParser.Handlers.Interfaces;
using Hirex.TestParser.Models;
using Hirex.TestParser.Services.Interfaces;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hirex.TestParser.Handlers.Implementations
{
    public class ParsingHandler : IParsingHandler
    {
        IDesignersService designersService;
        IWorksService worksService;
        public ParsingHandler(IDesignersService designersService, IWorksService worksService)
        {
            this.designersService = designersService;
            this.worksService = worksService;
        }

        public async Task Parse()
        {
            Console.WriteLine("Hi, enter your url here:");

            await StartParsing(Console.ReadLine()); //https://fonts.adobe.com/designers/
        }

        private async Task StartParsing(string link)
        {
            string html = await Download(link);

            List<string> linkList = GetAllLinks(html, "//div[@class=\"spectrum-grid-row\"]/div/a/span/../..", "<a href=\"(.*?)\"", link);

            foreach (string linkn in linkList)
            {
                DesignerModel designer = await ParseInfoFromDesignerPage(linkn, "//h1[@class=\"spectrum-Heading--display\"]", new Regex("<a ng-href=.*\\s*<\\/a>"), new Regex("<h1 class=.*?>\\s*(.*)\\s*"), new Regex("fonts\\/(.*)"), new Regex("ng-href=\"(.*?)\""));
                await designersService.AddDesigner(designer);
                Console.WriteLine($"The designer ({designer.Name}) has been added to database with him works");
            }
        }

        private async Task<string> Download(string link, Dictionary<string, string> headers = null)
        {
            string html= "";

            using (var wc = new WebClient())
            {
                if(headers!= null && headers.Count>0)
                    foreach (var header in headers)
                    {
                        wc.Headers.Add(header.Key, header.Value);
                    }

                html = await wc.DownloadStringTaskAsync(new Uri(link));
            }

            return html;
        }

        private List<string> GetAllLinks(string html, string xpath, string linkRegex, string baseUri)
        {
            List<string> links = new List<string>();

            HtmlDocument htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(html);

            foreach (var node in htmlDocument.DocumentNode.SelectNodes(xpath))
            {
                Regex regex = new Regex(linkRegex);
                if (regex.IsMatch(node.OuterHtml)) 
                {
                    links.Add(new Uri(new Uri(baseUri), regex.Match(node.OuterHtml).Groups[1].Value).ToString());
                }
            }

            Console.WriteLine($"All ({links.Count}) designer urls have been received.");

            return links;
        }

        private async Task<DesignerModel> ParseInfoFromDesignerPage(string link, string nameXpath, Regex worksRegex, Regex regexName, Regex regexWorkLink, Regex regexWorkName)
        {
            Console.WriteLine($"Download the information at the link:{link}");

            DesignerModel designer = new DesignerModel(); 

            string html = await Download(link);

            HtmlDocument htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(html);

            HtmlNode nodeName = htmlDocument.DocumentNode.SelectSingleNode(nameXpath);

            designer.Name = regexName.Match(nodeName.OuterHtml).Groups[1].Value;

            designer.Link = link;

            designer = await GetWorks(designer, link);

            return designer;
        }

        private async Task<DesignerModel> GetWorks(DesignerModel designer, string designerLink)
        {
            string linkToGetWorks = designerLink + "/families?browse_mode=default&sort=alpha";
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "accept", "application/json" },
                { "referer", designerLink },
                { "user-agent", "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.0.0 Mobile Safari/537.36"},

            };

            string result = await Download(linkToGetWorks, headers);
            dynamic works = StringToJson(result);

            if (works != null)
                foreach (var work in works.families_data.families)
                {
                    WorkModel workModel = new WorkModel();

                    workModel.WorkLink = (new Uri(new Uri(designerLink), "/fonts/"+work.slug)).ToString();

                    workModel.WorkName = work.name;

                    designer.Works.Add(workModel);
                }
            return designer;
        }

        private object StringToJson(string input)
        {
            try
            {
                return JsonConvert.DeserializeObject(input);
            }
            catch
            {
                return null;
            }
        }
    }
}
