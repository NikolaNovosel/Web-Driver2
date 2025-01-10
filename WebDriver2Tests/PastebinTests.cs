using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using WebDriver2;

namespace WebDriver2Tests;

public class PastebinTests
{
    private IWebDriver _driver;
    private Pastebin _pastebin;
    [SetUp]
    public void Setup()
    {
        _driver = new EdgeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait.TotalSeconds.Equals(5);
        _driver.Navigate().GoToUrl("https://pastebin.com/");
        _pastebin = new Pastebin(_driver);

    }
    //Arrange
    [TestCase("git config --global user.name" + 
        "\ngit reset $(git commit-tree HEAD^{tree} -m \"Legacy code\")" +
        "\ngit push origin master --force", "Bash", "how to gain dominance among developers")]
    public void TitlePasteName(string pasteText, string syntaxHightLight, string pasteName)
    {
        //Act
        _pastebin.EnterPasteText(pasteText);
        _pastebin.SetExpirationToTenMinutes();
        _pastebin.SetSyntaxHighlightingToBash();
        _pastebin.EnterPasteName(pasteName);
        _pastebin.CreatePaste();

        //Assert
        string pageTitle = _driver.Title;
        string nameText = _pastebin.ReturnNameText();
        string bashText = _pastebin.ReturnBashText();
        string paragraphText = _pastebin.ReturnParagraphText();
        Assert.That(pageTitle, Does.Contain(nameText));
        Assert.That(bashText, Is.EqualTo(syntaxHightLight));
        Assert.That(pasteText, Does.Contain(paragraphText));
    }
    [TearDown]
    public void TearDown()
    {
        _driver.Dispose();
    }
}