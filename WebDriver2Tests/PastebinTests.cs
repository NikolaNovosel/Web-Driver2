using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using WebDriver2;

namespace WebDriver2Tests;

public class PastebinTests
{
    //// Step 3: Verify results
    //string pageTitle = _pastebinPage.GetPageTitle();
    //Assert.AreEqual("how to gain dominance among developers", pageTitle, "Page title does not match.");

    //    string pasteCode = _pastebinPage.GetPasteCode();
    //Assert.AreEqual("git config --global user.name  \"New Sheriff in Town\"\n" +
    //                    "git reset $(git commit-tree HEAD^{tree} -m \"Legacy code\")\n" +
    //                    "git push origin master --force", pasteCode, "Code does not match.");

    //    string syntaxHighlighting = _pastebinPage.GetSyntaxHighlighting();
    //Assert.AreEqual("Bash", syntaxHighlighting, "Syntax highlighting is incorrect.");

    private IWebDriver driver;
    private Pastebin pastebin;
    [SetUp]
    public void Setup()
    {
        driver = new EdgeDriver();
        driver.Manage().Window.FullScreen();
        driver.Manage().Timeouts().ImplicitWait.TotalSeconds.Equals(10);
        driver.Navigate().GoToUrl("https://pastebin.com/");
        pastebin = new Pastebin(driver);

    }
    [Test]
    public void TitlePasteName()
    {
        pastebin.EnterPasteText("git config --global user.name  \"New Sheriff in Town\"\r\ngit reset $(git commit-tree HEAD^{tree} -m \"Legacy code\")\r\ngit push origin master --force\r\n");
        pastebin.SetExpirationToTenMinutes();
        pastebin.SetSyntaxHighlightingToBash();
        pastebin.EnterPasteName("how to gain dominance among developers");
        pastebin.CreatePaste();

        string pageTitle = driver.Title;
        string expected = "how to gain dominance among developers";
        Assert.That(expected, Is.EqualTo(pageTitle), "Page title does not match.");
    }
    [Test]
    public void SyntaxHighLightBashSuspended()
    {
        pastebin.EnterPasteText("git config --global user.name  \"New Sheriff in Town\"\r\ngit reset $(git commit-tree HEAD^{tree} -m \"Legacy code\")\r\ngit push origin master --force\r\n");
        pastebin.SetExpirationToTenMinutes();
        pastebin.SetSyntaxHighlightingToBash();
        pastebin.EnterPasteName("how to gain dominance among developers");
        pastebin.CreatePaste();
        Assert.IsTrue(pastebin.BashOption.Displayed, "Bash' option is not displayed.");
    }
    [Test]
    public void TitlePasteTextAreaParagraph2()
    {
        pastebin.EnterPasteText("git config --global user.name  \"New Sheriff in Town\"\r\ngit reset $(git commit-tree HEAD^{tree} -m \"Legacy code\")\r\ngit push origin master --force\r\n");
        pastebin.SetExpirationToTenMinutes();
        pastebin.SetSyntaxHighlightingToBash();
        pastebin.EnterPasteName("how to gain dominance among developers");
        pastebin.CreatePaste();
        string pageTitle = driver.Title;
        Assert.IsTrue(pageTitle.Contains("git reset $(git commit-tree HEAD^{tree} -m \"Legacy code\")"), "The paste text paragraph 2 is incorrect.");
    }
    [TearDown]
    public void TearDown()
    {
        driver.Dispose();
    }
}