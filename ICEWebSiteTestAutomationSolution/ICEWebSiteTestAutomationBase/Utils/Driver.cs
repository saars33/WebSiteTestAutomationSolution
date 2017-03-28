using System;
using System.Diagnostics;
using ICEWebSiteTestAutomationBase.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace ICEWebSiteTestAutomationBase.Utils
{
    public class Driver
    {
        public enum BrowserName
        {
            NULL,
            FIREFOX,
            GOOGLECHROME,
            SAUCELABS,
            IE,
            HTMLUNIT,
            GRID,
            FIREFOXPORTABLE,
            FIREFOXMARIONETTE,
            APPIUM,
            EDGE
        }

        public const long DefaultTimeoutSeconds = 10;
        public const string BrowserPropertyName = "selenium.webdriver";
        private const string DefaultBrowser = "FIREFOX";
        private static IWebDriver _aDriver;
        private static long _browserStartTime;
        private static long _savedTimeCount;
        private static bool _avoidRecursiveCall;
        private static BrowserName _useThisDriver = BrowserName.NULL;

        public static BrowserName CurrentDriver { get; set; }

        // default for browsermob localhost:8080
        // default for fiddler: localhost:8888
        public static string ProxyHost { get; set; } = "localhost";

        public static string ProxyPort { get; set; } = "8888";

        public static string Proxy { get; set; } = ProxyHost + ":" + ProxyPort;

        public static void Set(BrowserName browserName)
        {
            _useThisDriver = browserName;

            //close any existing driver
            if (_aDriver != null)
            {
                _aDriver.Quit();
                _aDriver = null;
            }
        }

        public static IWebDriver Get()
        {
            if (_useThisDriver == BrowserName.NULL)
            {
                var defaultBrowser = EnvironmentPropertyReader.GetPropertyOrEnv(BrowserPropertyName, DefaultBrowser);
                switch (defaultBrowser)
                {
                    case "FIREFOX":
                        _useThisDriver = BrowserName.FIREFOX;
                        break;
                    case "CHROME":
                        _useThisDriver = BrowserName.GOOGLECHROME;
                        break;
                    case "IE":
                        _useThisDriver = BrowserName.IE;
                        break;
                    case "SAUCELABS":
                        _useThisDriver = BrowserName.SAUCELABS;
                        break;
                    case "HTMLUNIT":
                        _useThisDriver = BrowserName.HTMLUNIT;
                        break;
                    case "GRID":
                        _useThisDriver = BrowserName.GRID;
                        break;
                    default:
                        throw new UnknownBrowserException("Unknown Browser in " + BrowserPropertyName + ": " +
                                                          defaultBrowser);
                }
            }

            if (_aDriver == null)
            {
                var startBrowserTime = DateTimeUtils.CurrentTimeMillis();
                switch (_useThisDriver)
                {
                    case BrowserName.FIREFOX:

                        //the next steps will launch browser, navigate to the page and click the login button
                        //todo: change the path of the ff service to be in project
                        /*FirefoxDriverService firefoxDriverService =
                            FirefoxDriverService.CreateDefaultService(
                                @"C:\Users\Public\AutomationSpecificFolders\sel_resources_go_here");*/

                        var firefoxBinary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
                        var firefoxProfile = new FirefoxProfile();
                        firefoxProfile.EnableNativeEvents = true;
                        _aDriver = new FirefoxDriver(firefoxBinary, firefoxProfile);
                        CurrentDriver = BrowserName.FIREFOX;
                        break;
                    case BrowserName.GOOGLECHROME:
                        var chromeOptions = new ChromeOptions();
                        chromeOptions.AddArguments("disable-plugins", "disable-extentions", "test-type");
                        /*DesiredCapabilities chromeDesiredCapabilities=DesiredCapabilities.Chrome();
                        chromeDesiredCapabilities.SetCapability(ChromeOptions.Capability,chromeOptions);
*/
                        var chromeDriverService = ChromeDriverService.CreateDefaultService(
                            @"C:\Users\Public\AutomationSpecificFolders\sel_resources_go_here");

                        _aDriver = new ChromeDriver(chromeDriverService, chromeOptions);
                        CurrentDriver = BrowserName.GOOGLECHROME;
                        break;
                    default:
                        throw new UnknownBrowserException("Unknown/Unsupported Browser :" + _useThisDriver);
                }
                var browserStartedTime = DateTimeUtils.CurrentTimeMillis();
                _browserStartTime = browserStartedTime - startBrowserTime;
                AppDomain.CurrentDomain.ProcessExit += CloseBroserOnProcessExit;
            }
            else
            {
                try
                {
                    if (_aDriver.CurrentWindowHandle != null)
                    {
                        //assume it is still alove
                    }
                }
                catch (Exception)
                {
                    if (_avoidRecursiveCall)
                        throw new UnknownBrowserException(
                            "Something has gone wrong as we have been in Driver.Get already");
                    Quit();
                    _aDriver = null;
                    _avoidRecursiveCall = true;
                    return Get();
                }
                _savedTimeCount += _browserStartTime;
                Debug.WriteLine("Saved another " + _browserStartTime + " ms: total saved " + _savedTimeCount + " ms");
            }
            _avoidRecursiveCall = false;
            return _aDriver;
        }

        private static void CloseBroserOnProcessExit(object sender, EventArgs e)
        {
            Quit();
        }

        public static IWebDriver Get(string url, bool maximize)
        {
            Get();
            _aDriver.Navigate().GoToUrl(url);
            if (maximize)
                try
                {
                    _aDriver.Manage().Window.Maximize();
                }
                catch (WebDriverException exception)
                {
                    Debug.WriteLine("Remote Driver does not support maximize. The error thrown is " +
                                    exception.StackTrace);
                    throw;
                }
            return _aDriver;
        }

        public static IWebDriver Get(string url)
        {
            return Get(url, true);
        }

        private static void Quit()
        {
            if (_aDriver != null)
            {
                Debug.WriteLine(" total time saved by reusing browsers " + _savedTimeCount + " ms ");
                try
                {
                    _aDriver.Quit();
                    _aDriver = null;
                }
                catch (Exception)
                {
                    //I dont care about errors at this point
                }
            }
        }
    }
}