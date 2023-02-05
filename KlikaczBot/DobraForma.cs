using KlikaczBot.BrowserInteractions;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Microsoft.VisualBasic.ApplicationServices;
using System.Runtime.InteropServices;

namespace KlikaczBot
{
    public partial class DobraForma : Form
    {
        private const string SiteUrl = @"https://www.okta.com/";

        public DobraForma()
        {
            InitializeComponent();
            //var c = new BrowserDataObtainer();
            //var p = c.GetPagesFromBrowser();

            labLoadedSite.Text = "Brak";
            pointerPosTimer.Tick += PointerPosTimer_Tick;
            pointerPosTimer.Start();
        }

        private void PointerPosTimer_Tick(object? sender, EventArgs e)
        {
            var pointerPos = new System.Drawing.Point();
            GetCursorPos(ref pointerPos);
            labXPointerPos.Text = pointerPos.X.ToString();
            labYPointerPos.Text = pointerPos.Y.ToString();
        }

        private System.Windows.Forms.Timer pointerPosTimer = new System.Windows.Forms.Timer();


        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref System.Drawing.Point lpPoint);

        private async void btnClick_Click(object sender, EventArgs e)
        {
            
            IBrowserFetcher fecher = new BrowserFetcher();
            await fecher.DownloadAsync();

            var options = new ConnectOptions()
            {
                BrowserURL = @"http://127.0.0.1:9222", DefaultViewport = null
            };
            var browser = await Puppeteer.ConnectAsync(options);
            //var pages = await browser.PagesAsync();
            var checkingPage = await browser.NewPageAsync();

            await checkingPage.GoToAsync(SiteUrl);
            labLoadedSite.Text = checkingPage.Url;
            //var siteHtmlString = await checkingPage.GetContentAsync();

            var button = await checkingPage.QuerySelectorAsync("[class='Button Button-primary-large  css-pld3e6']");
            var boundBox =  await button.BoundingBoxAsync();

            await checkingPage.CloseAsync();
            
            
            
            
            ///HtmlAgilityPack.HtmlDocument htmlDocument = new();
            ///htmlDocument.LoadHtml(siteHtmlString);
            //var buttons =  htmlDocument.DocumentNode.SelectNodes("//button");
            //var buttonNodes = htmlDocument.DocumentNode.DescendantsAndSelf().Where(x => x.HasClass("Button")).ToList();
            

            //var page = pages.Where( p => p.Url = );


            //var checkingPage = await browser.NewPageAsync();

            //await checkingPage.GoToAsync(@"https://bot.sannysoft.com/");
            //await checkingPage.GoToAsync(@"https://nowsecure.nl/");


            //var browser = await Puppeteer.LaunchAsync(new LaunchOptions() { Headless = false });
            //var page = await browser.NewPageAsync();
            //await page.GoToAsync(@"https://bot.sannysoft.com/");

        }

        private void labXButtonPos_Click(object sender, EventArgs e)
        {

        }
    }
}
