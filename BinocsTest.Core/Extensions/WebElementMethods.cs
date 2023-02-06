using OpenQA.Selenium;

namespace BinocsTest.Core.Extensions
{
    public static class WebElementMethods
    {
        public static void InsertText(this IWebElement webElement, string text)
        {
            webElement.Clear();
            webElement.SendKeys(text);
        }
    }
}
