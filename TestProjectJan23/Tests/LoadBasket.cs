using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using TestProjectJan23.Pages;

namespace TestProjectJan23.Tests
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            driver = new ChromeDriver(outPutDirectory);
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
        }


        [Test]
        [TestCase(TestName = "0100 - Shop By Brand", Author = "stuart.ducasse")]
        //[Property("Priority", Variables.TestPriority.Release)]
        public void ByBrand()
        {
            var homePage = new HomePage(driver);
            homePage.Open();
            homePage.AcceptCookies();
            homePage.ClickAllDepartments();
            homePage.ClickHomeGardenPets();
            homePage.ClickPetSupplies();
            homePage.ClickDogsCategory();
            homePage.HoverFoodDry();
            homePage.ClickDogTreatsJpeg();
            homePage.ClickDentalSticksJpeg();
            homePage.PageDown();
            homePage.SelectFoodBrandPedigreeCheckbox();
            homePage.ClickDentaStix();

            // Assert the Product and the Price are correct 
            Assert.Multiple(() =>
            {
                //Assert.That(homePage.toolbarBasket.Text, Is.EqualTo("1"));
                Assert.That(homePage.prodTitlePedigreeDentaStix.Text, Is.EqualTo("Pedigree Dentastix - Fresh Daily Dental Chews Medium Dog, 112 Sticks - 2.88 kg megapack (4 x 28 Sticks)"));
                Assert.That(homePage.prodPricePedigreeDentaStix.Text, Is.EqualTo("£22.50 (£0.20 / count)"));
                StringAssert.Contains("Pedigree Dentastix - Fresh Daily Dental Chews Medium Dog", homePage.prodTitlePedigreeDentaStix.Text);
            });

            // Edit Basket increase quantity from 1 to 4
            //homePage.EditBasket();
            //homePage.CompletePurchase();
            homePage.ClickAddToBasket();
            homePage.ClickToolbarBasket();
            homePage.ChangeQtyToFour();

            Assert.Multiple(() =>
            {
                Assert.That(homePage.toolbarBasket.Text, Is.EqualTo("4"));
                Assert.That(homePage.basketSubTotal.Text, Is.EqualTo(" £100.00"));
            });

            homePage.ClickShoppingBasketProduct();
            homePage.SwitchNewTab();
            homePage.PageDown();
            homePage.ClickProductThisItem();
            homePage.ClickBtnAddBothToBasket();
            homePage.ClickGoToBasket();

            Assert.Multiple(() =>
            {
                Assert.That(homePage.toolbarBasket.Text, Is.EqualTo("6"));
                StringAssert.Contains("Pedigree DentaStix - Daily Dental Chews For Medium Dogs (10 - 25 kg), 2.88 kg (1 x 112 Sticks)", homePage.itemOneBasketProdName.Text);
                StringAssert.Contains("1", homePage.itemOneBasketProdQty.Text);
                StringAssert.Contains("Pedigree Schmackos Mega Pack - Dog treat multipack with beef, lamb and poultry flavours, 5 x (22 Pc / 158 g) ", homePage.itemTwoBasketProdName.Text);
                StringAssert.Contains("1", homePage.itemTwoBasketProdQty.Text);
                StringAssert.Contains("Pedigree Dentastix - Fresh Daily Dental Chews Medium Dog, 112 Sticks - 2.88 kg megapack (4 x 28 Sticks)", homePage.itemThreeBasketProdName.Text);
                StringAssert.Contains("4", homePage.itemThreeBasketProdQty.Text);
            });
        }

        [Test]
        [TestCase(TestName = "0200 - Shop By Type", Author = "stuart.ducasse")]
        //[Property("Priority", Variables.TestPriority.Release)]
        public void ByType()
        {
            var homePage = new HomePage(driver);
            homePage.Open();
            homePage.AcceptCookies();
            homePage.ClickAllDepartments();
            homePage.ClickHomeGardenPets();
            homePage.ClickPetSupplies();
            homePage.ClickSideMenuDeptDogs();
            homePage.ClickSideMenuDogsTreats();
            homePage.ClickSideMenuFeaturedBrandPedigree();
            homePage.ClickDentaStix();

            // Assert the Product and the Price are correct 
            Assert.Multiple(() =>
            {
                //Assert.That(homePage.toolbarBasket.Text, Is.EqualTo("1"));
                Assert.That(homePage.prodTitlePedigreeDentaStix.Text, Is.EqualTo("Pedigree Dentastix - Fresh Daily Dental Chews Medium Dog, 112 Sticks - 2.88 kg megapack (4 x 28 Sticks)"));
                Assert.That(homePage.prodPricePedigreeDentaStix.Text, Is.EqualTo("£22.50 (£0.20 / count)"));
                StringAssert.Contains("Pedigree Dentastix - Fresh Daily Dental Chews Medium Dog", homePage.prodTitlePedigreeDentaStix.Text);
            });

            // Edit Basket increase quantity from 1 to 4
            homePage.EditBasket();

            Assert.Multiple(() =>
            {
                Assert.That(homePage.toolbarBasket.Text, Is.EqualTo("4"));
                Assert.That(homePage.basketSubTotal.Text, Is.EqualTo(" £100.00"));
            });

            // add 2 new items to basket
            homePage.CompletePurchase();

            Assert.Multiple(() =>
            {
                Assert.That(homePage.toolbarBasket.Text, Is.EqualTo("6"));
                StringAssert.Contains("Pedigree DentaStix - Daily Dental Chews For Medium Dogs (10 - 25 kg), 2.88 kg (1 x 112 Sticks)", homePage.itemOneBasketProdName.Text);
                StringAssert.Contains("1", homePage.itemOneBasketProdQty.Text);
                StringAssert.Contains("Pedigree Schmackos Mega Pack - Dog treat multipack with beef, lamb and poultry flavours, 5 x (22 Pc / 158 g) ", homePage.itemTwoBasketProdName.Text);
                StringAssert.Contains("1", homePage.itemTwoBasketProdQty.Text);
                StringAssert.Contains("Pedigree Dentastix - Fresh Daily Dental Chews Medium Dog, 112 Sticks - 2.88 kg megapack (4 x 28 Sticks)", homePage.itemThreeBasketProdName.Text);
                StringAssert.Contains("4", homePage.itemThreeBasketProdQty.Text);
            });
        }

        [Test]
        [TestCase(TestName = "0300 - Shop By Search", Author = "stuart.ducasse")]
        public void BySearch()
        {
            var homePage = new HomePage(driver);
            homePage.Open();
            homePage.AcceptCookies();
            homePage.SearchDogDentalSticks();
            homePage.ClickDentaStix();

            // Edit Basket increase quantity from 1 to 4
            homePage.EditBasket();

            Assert.Multiple(() =>
            {
                Assert.That(homePage.toolbarBasket.Text, Is.EqualTo("4"));
                Assert.That(homePage.basketSubTotal.Text, Is.EqualTo(" £100.00"));
            });

            // add 2 new items to basket
            homePage.CompletePurchase();

            Assert.Multiple(() =>
            {
                Assert.That(homePage.toolbarBasket.Text, Is.EqualTo("6"));
                StringAssert.Contains("Pedigree DentaStix - Daily Dental Chews For Medium Dogs (10 - 25 kg), 2.88 kg (1 x 112 Sticks)", homePage.itemOneBasketProdName.Text);
                StringAssert.Contains("1", homePage.itemOneBasketProdQty.Text);
                StringAssert.Contains("Pedigree Schmackos Mega Pack - Dog treat multipack with beef, lamb and poultry flavours, 5 x (22 Pc / 158 g) ", homePage.itemTwoBasketProdName.Text);
                StringAssert.Contains("1", homePage.itemTwoBasketProdQty.Text);
                StringAssert.Contains("Pedigree Dentastix - Fresh Daily Dental Chews Medium Dog, 112 Sticks - 2.88 kg megapack (4 x 28 Sticks)", homePage.itemThreeBasketProdName.Text);
                StringAssert.Contains("4", homePage.itemThreeBasketProdQty.Text);
            });


        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}