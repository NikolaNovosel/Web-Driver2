using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebDriver2;

public class Pastebin
{
    private readonly IWebDriver _driver;
    public Pastebin(IWebDriver driver)
    {
        _driver = driver;
    }

    public IWebElement PasteTextArea => _driver.FindElement(By.Id("postform-text"));
    public IWebElement DropDownListExpiration => _driver.FindElement(By.Id("select2-postform-expiration-container"));
    public IWebElement DropDownListSyntaxHighLight => _driver.FindElement(By.Id("select2-postform-format-container"));
    public IWebElement TenMinutesOption => _driver.FindElement(By.XPath("//li[text()='10 Minutes']"));
    public IWebElement BashOption => _driver.FindElement(By.XPath("//li[text()='Bash']"));
    public IWebElement PasteNameField => _driver.FindElement(By.Id("postform-name"));
    public IWebElement CreatePasteButton => _driver.FindElement(By.XPath("//button[text()='Create New Paste']"));
    public void EnterPasteText(string text)
    {
        PasteTextArea.SendKeys(text);
    }
    public void SetExpirationToTenMinutes()
    {
        DropDownListExpiration.Click();
        TenMinutesOption.Click();
    }
    public void SetSyntaxHighlightingToBash()
    {
        DropDownListSyntaxHighLight.Click();
        BashOption.Click();
    }
    public void EnterPasteName(string name)
    {
        PasteNameField.SendKeys(name);
    }
    public void CreatePaste()
    {
        CreatePasteButton.Click();
    }
}
