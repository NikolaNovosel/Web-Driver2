using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WebDriver2;
public class Pastebin
{
    private readonly IWebDriver _driver;
    private readonly Actions _actions;
    public Pastebin(IWebDriver driver)
    {
        _driver = driver;
        _actions = new Actions(_driver);
    }
    private IWebElement PasteTextArea => _driver.FindElement(By.Id("postform-text"));
    private IWebElement DropDownListExpiration => _driver.FindElement(By.Id("select2-postform-expiration-container"));
    private IWebElement DropDownListSyntaxHighLight => _driver.FindElement(By.Id("select2-postform-format-container"));
    private IWebElement PostFormLeft => _driver.FindElement(By.ClassName("post-form__left"));
    private IWebElement TenMinutesOption => PostFormLeft.FindElement(By.XPath("//li[text()='10 Minutes']"));
    private IWebElement BashOption => PostFormLeft.FindElement(By.XPath("//li[text()='Bash']"));
    private IWebElement PasteNameField => _driver.FindElement(By.Id("postform-name"));
    private IWebElement CreatePasteButton => PostFormLeft.FindElement(By.XPath("//button[text()='Create New Paste']"));
    private IWebElement Footer => _driver.FindElement(By.ClassName("top-footer"));
    private IWebElement BashOptionResult => _driver.FindElement(By.XPath("//div[@class='highlighted-code']//a[text()='Bash']"));
    private IWebElement PasteNameFieldResult => _driver.FindElement(By.XPath("//div[@class='details']//div[@class='info-top']/h1"));
    private IWebElement ParagraphResult => _driver.FindElement(By.XPath("//ol[@class='bash']//li[2]//span[@class='kw2']"));
    public void EnterPasteText(string text)
    {
        PasteTextArea.SendKeys(text);
    }
    public void SetExpirationToTenMinutes()
    {
        _actions.ScrollToElement(PostFormLeft).Perform();
        DropDownListExpiration.Click();
        TenMinutesOption.Click();
    }
    public void SetSyntaxHighlightingToBash()
    {
        _actions.ScrollToElement(PostFormLeft).Perform();
        DropDownListSyntaxHighLight.Click();
        BashOption.Click();
    }
    public void EnterPasteName(string name) => PasteNameField.SendKeys(name);
    public void CreatePaste()
    {
        _actions.ScrollToElement(Footer).Perform();
        CreatePasteButton.Click();
    }
    public string ReturnBashText() => BashOptionResult.Text;
    public string ReturnNameText() => PasteNameFieldResult.Text;
    public string ReturnParagraphText() => ParagraphResult.Text;
}
