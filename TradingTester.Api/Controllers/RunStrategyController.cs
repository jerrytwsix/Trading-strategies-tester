using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TradingTester.Api.Controllers
{
    [Route("strategy")]
    [ApiController]
    public class RunStrategyController : ControllerBase
    {
        [HttpGet]
        public string RunStrategy()
        {
            string fileName = @"C:\ThingsForWork\Trading-strategies-tester\TradingTester.Api\wwwroot\Strategy\strategy.py";
            
            if (System.IO.File.Exists(fileName))
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(@"C:\Program Files\Python39\python.exe", fileName)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = false
                };
                p.Start();

                p.WaitForExit();

                return "Strategy completed";
            }

            return "File doesn't exist";
        }
    }
}
