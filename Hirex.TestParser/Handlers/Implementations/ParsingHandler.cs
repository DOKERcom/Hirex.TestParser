using Hirex.TestParser.Handlers.Interfaces;
using Hirex.TestParser.Models;
using Hirex.TestParser.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hirex.TestParser.Handlers.Implementations
{
    public class ParsingHandler : IParsingHandler
    {
        IDesignersService designersService;
        public ParsingHandler(IDesignersService designersService)
        {
            this.designersService = designersService;
        }

        public void Parse()
        {
            Console.WriteLine("Hi, enter your url here:");

            designersService.AddDesigner(new DesignerModel { Name = "DOKERcom", Link = "work.ua" });

            //designersService.DeleteDesigner();

            string url = Console.ReadLine();
        }

        private List<string> GetAllLinks()
        {
            return null;
        }

        private DesignerModel ParseInfoFromPage()
        {
            return null;
        }
    }
}
