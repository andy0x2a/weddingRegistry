using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium;
using System.Web.Http;
using System.Threading;
using System.Web.Http.Cors;

namespace weddingRegistryChecker.Controllers
{
 
    /// <summary>
    /// The response object
    /// </summary>
    public class ResponseObj
    {
        /// <summary>
        /// Fully purchased count
        /// </summary>
        public int fullyPurchased { get; set; }
        /// <summary>
        /// Remaining count
        /// </summary>
        public int remaining { get; set; }
        /// <summary>
        /// Total count
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// should Email
        /// </summary>
        public bool shouldEmail { get; set; }

    }
    /// <summary>
    /// The main controller
    /// </summary>
    public class MainController : ApiController
    {

        private static int total = -1;

        /// <summary>
        /// Resets everything
        /// </summary>
       public void reset()
        {
            MainController.total = -1;
        }
        /// <summary>
        /// Gets the count of gifts bought for the registry
        /// </summary>
        /// <returns></returns>
        /// 
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        public ResponseObj GetStuff()
        {


            IWebDriver driver = new PhantomJSDriver(); 
        var responseObj = new ResponseObj()
            { total = 70,
                shouldEmail = false
        };
            driver.Navigate().GoToUrl("http://giftregistry.hbc.com/grworks/prj/generic_online/jsp/common/grbookmark.jsp?retailerid=4&registryid=400125857907");
            //Thread.Sleep(5000);
         
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            responseObj.remaining= (int)Convert.ToInt32(js.ExecuteScript("return formElems.formElements.length"));
            responseObj.fullyPurchased = responseObj.total - responseObj.remaining;
            if (MainController.total < responseObj.fullyPurchased)
            {
                MainController.total = responseObj.fullyPurchased;
                responseObj.shouldEmail = true;
            }

            return responseObj;
            
        }
    }
}
