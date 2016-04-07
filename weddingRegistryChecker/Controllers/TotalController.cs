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
    /// The main controller
    /// </summary>
    public class TotalController 
        //: ApiController
    {

        private static int total = -1;



        /// <summary>
        /// stores the total
        /// </summary>
        /// <param name="total"> the total</param>
        ///    /// 
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        public void storeTotal(int total)
        {
            TotalController.total= total;
        }

        /// <summary>
        /// gets the total
        /// </summary>
        /// <returns>the total</returns>
        ///    /// 
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        public int getTotal()
        {
            return TotalController.total;
        }

     
    }
}
