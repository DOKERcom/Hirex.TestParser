using Hirex.TestParser.BLL.Services.Interfaces;
using Hirex.TestParser.Handlers.Interfaces;
using Hirex.TestParser.Models;
using Hirex.TestParser.Services.Interfaces;
using HtmlAgilityPack;
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
            string link = "https://fonts.adobe.com/designers/";

            string vff = await Download("https://fonts.adobe.com/designers/christian-schwartz/families?browse_mode=default&sort=alpha");

            //string html = await Download(link);

            //List<string> linkList = GetAllLinks(html, "//div[@class=\"spectrum-grid-row\"]/div/a/span/../..", "<a href=\"(.*?)\"", link);

            //foreach (string linkn in linkList)
            //{
            //   await designersService.AddDesigner(await ParseInfoFromDesignerPage(linkn,"//h1[@class=\"spectrum-Heading--display\"]", new Regex("<a ng-href=.*\\s*<\\/a>"), new Regex("<h1 class=.*?>\\s*(.*)\\s*"), new Regex("fonts\\/(.*)"), new Regex("ng-href=\"(.*?)\"")));
            //}

            //designersService.AddWorkToDesignerById((await designersService.GetDesignerByLink("work.ua")).Id, (await worksService.GetWorkByLink("work.td")).Id).Wait();
            //designersService.DeleteWorkFromDesignerById((await designersService.GetDesignerByLink("work.ua")).Id, (await worksService.GetWorkByLink("work.td")).Id).Wait();
            Console.ReadLine();
        }

        private async Task<string> Download(string link)
        {
            string html= "";
            using (var wc = new WebClient())
            {
                wc.Headers. = "browse_mode=default&sort=alpha";
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

            return links;
        }

        private async Task<DesignerModel> ParseInfoFromDesignerPage(string link, string nameXpath, Regex worksRegex, Regex regexName, Regex regexWorkLink, Regex regexWorkName)
        {
            DesignerModel designer = new DesignerModel(); 

            string html = await Download(link);

            HtmlDocument htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(html);

            HtmlNode nodeName = htmlDocument.DocumentNode.SelectSingleNode(nameXpath);

            MatchCollection works = worksRegex.Matches(html);

            designer.Name = regexName.Match(nodeName.OuterHtml).Groups[1].Value;

            designer.Link = link;

            if(works != null)
                foreach (Match work in works)
                {
                    WorkModel workModel = new WorkModel();

                    workModel.WorkLink = new Uri(new Uri(link), regexWorkLink.Match(work.Value).Groups[1].Value).ToString();

                    workModel.WorkName = regexWorkName.Match(workModel.WorkLink).Groups[1].Value;

                    designer.Works.Add(workModel);
                }

            return designer;
        }

        private async Task StartLinkParsing(List<string> listLinks)
        {
            foreach (string link in listLinks)
            {
               string html = await Download(link);
            }
        }
    }
}
