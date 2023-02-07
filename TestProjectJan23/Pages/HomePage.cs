using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

using System.Xml.Linq;

namespace TestProjectJan23.Pages
{
    public class HomePage
    {
        public HomePage(IWebDriver driver)
        {
            Driver = driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebDriver Driver { get; }

        // web elements Home Page
        public IWebElement btnCookieConsent => Driver.FindElement(By.CssSelector("#sp-cc-accept"));
        public IWebElement btnAllDepartments => Driver.FindElement(By.CssSelector("#nav-hamburger-menu"));
        public IWebElement deptHomeGardenPets => Driver.FindElement(By.CssSelector("ul.hmenu.hmenu-visible > li:nth-child(20)"));
        public IWebElement petSupplies => Driver.FindElement(By.CssSelector("ul.hmenu.hmenu-visible.hmenu-translateX > li:nth-child(27)"));
        public IWebElement categoryDogsJpeg => Driver.FindElement(By.CssSelector(".a-list-item"));
        public IWebElement dryDogFood => Driver.FindElement(By.CssSelector("ul > span:nth-child(1) > li > span > div > div > a:nth-child(1)"));
        public IWebElement dogsFoodJpeg => Driver.FindElement(By.CssSelector("[title='Food']"));
        public IWebElement dogTreatsJpeg => Driver.FindElement(By.CssSelector("[title='Treats']"));
        public IWebElement checkboxBrandPedigree => Driver.FindElement(By.CssSelector("#p_89\\/Pedigree > span > a > div > label > i"));
        public IWebElement deptDryDogFood => Driver.FindElement(By.CssSelector("#n\\/13154141031"));
        public IWebElement itemWeight1To1_9Kg => Driver.FindElement(By.CssSelector("#p_n_feature_two_browse-bin\\/42254101031"));
        public IWebElement containerTypeTub => Driver.FindElement(By.CssSelector("[aria-label='Tub'] .a-icon"));
        public IWebElement dentalSticksJpeg => Driver.FindElement(By.CssSelector("[title='Dental Sticks']"));
        public IWebElement prodPedigreeDentaStix => Driver.FindElement(By.PartialLinkText("Medium Dog, 112 Sticks - 2.88 kg megapack"));
        public IWebElement prodTitlePedigreeDentaStix => Driver.FindElement(By.CssSelector("#productTitle"));
        public IWebElement prodPricePedigreeDentaStix => Driver.FindElement(By.CssSelector("span[id='sns-base-price']"));

        // by Type Test Elements                                                  
        public IWebElement sideMenuDeptDogs => Driver.FindElement(By.CssSelector("#s-refinements > div:nth-child(2) > ul > li:nth-child(4) > span > a"));
        public IWebElement sideMenuDogsTreats => Driver.FindElement(By.CssSelector("li:nth-child(19) span:nth-child(1) a:nth-child(1) span:nth-child(1)"));
        public IWebElement sideMenuFeaturedBrandPedigree => Driver.FindElement(By.XPath("//span[@class='a-size-base a-color-base'][normalize-space()='Pedigree']"));

        // search string
        public IWebElement searchBox => Driver.FindElement(By.CssSelector("#twotabsearchtextbox"));


        // web elements basket and checkout
        public IWebElement caratOneTimePurchase => Driver.FindElement(By.CssSelector("#newAccordionRow > div > div.a-accordion-row-a11y.a-accordion-row.a-declarative.accordion-header.mobb-header-css > i"));
        public IWebElement btnOneTimePurchase => Driver.FindElement(By.CssSelector(".a-icon.a-accordion-radio.a-icon-radio-inactive"));
        public IWebElement paneOneTimePurchase => Driver.FindElement(By.CssSelector("#newAccordionRow"));
        public IWebElement btnAddToBasket => Driver.FindElement(By.CssSelector("#add-to-cart-button"));
        public IWebElement toolbarBasket => Driver.FindElement(By.CssSelector("#nav-cart-count"));
        public IWebElement dropdownQtyBasket => Driver.FindElement(By.CssSelector("span[class='a-button-text a-declarative']"));
        public IWebElement dropdownQty4 => Driver.FindElement(By.CssSelector("#quantity_4"));
        public IWebElement basketSubTotal => Driver.FindElement(By.CssSelector("span[id='sc-subtotal-amount-buybox']"));
        public IWebElement shoppingBasketProduct => Driver.FindElement(By.CssSelector("span[class='a-truncate-full']"));
        public IWebElement productThisItem => Driver.FindElement(By.CssSelector("#fbtCheck-1"));
        public IWebElement btnAddBothToBasket => Driver.FindElement(By.CssSelector("input[name='submit.addToCart']"));
        public IWebElement subtotal2Items => Driver.FindElement(By.CssSelector("span[id='sc-subtotal-amount-buybox']"));
        public IWebElement body => Driver.FindElement(By.TagName("body"));
        public IWebElement newBasketSubTotal => Driver.FindElement(By.CssSelector("#sw-subtotal > span:nth-child(2) > span"));
        public IWebElement btnGoToBasket => Driver.FindElement(By.XPath("//*[@id=\'sw-gtc\']"));
        public IWebElement totalNoItemsBasket => Driver.FindElement(By.XPath("//*[@id=\'sw-gtc\']"));
        public IWebElement shoppingBasket => Driver.FindElement(By.XPath("#sc-active-cart"));
        public IWebElement itemOneBasketProdName => Driver.FindElement(By.XPath("//span[@class='a-truncate-cut'][contains(text(),'Pedigree DentaStix - Daily Dental Chews For Medium')]"));
        public IWebElement itemOneBasketProdQty => Driver.FindElement(By.CssSelector("#a-autoid-1-announce"));
        public IWebElement itemTwoBasketProdName => Driver.FindElement(By.XPath("//span[@class='a-truncate-cut'][contains(text(),'Pedigree Schmackos Mega Pack - Dog treat multipack')]"));
        public IWebElement itemTwoBasketProdQty => Driver.FindElement(By.CssSelector("#a-autoid-3-announce"));
        public IWebElement itemThreeBasketProdName => Driver.FindElement(By.XPath("//span[@class='a-truncate-cut'][contains(text(),'Pedigree Dentastix - Fresh Daily Dental Chews Medi')]"));
        public IWebElement itemThreeBasketProdQty => Driver.FindElement(By.CssSelector("#a-autoid-5-announce"));

        // implements an explicit wait
        public void WaitForElementToBeVisible(By locator, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        // open HomePage
        public HomePage Open()
        {
            Driver.Navigate().GoToUrl("https://www.amazon.co.uk/");
            return this;
        }

        // acceptCookieConsent
        public HomePage AcceptCookies()
        {
            try
            {
                if (btnCookieConsent.Displayed)
                {
                    btnCookieConsent.Click();
                }
            }
            catch (NoSuchElementException)
            {
                // Do nothing, cookie button not present
            }
            return this;
        }

        // searchBox
        public HomePage SearchDogDentalSticks() 
        {
            WaitForElementToBeVisible(By.CssSelector("#twotabsearchtextbox"), 60);
            searchBox.SendKeys("dog dental sticks");
            searchBox.Submit();
            return this;
        }


        // clickAllDepartments
        public HomePage ClickAllDepartments()
        {
            btnAllDepartments.Click();
            WaitForElementToBeVisible(By.CssSelector("#nav-hamburger-menu"), 10);
            return this;
        }

        // edit and amend basket
        public HomePage EditBasket()
        {
            ClickAddToBasket();
            ClickToolbarBasket();
            ChangeQtyToFour();
            return this;
        }

        // complete the purchase
        public HomePage CompletePurchase()
        {
            ClickShoppingBasketProduct();
            SwitchNewTab();
            PageDown();
            Actions action = new Actions(Driver);
            action.MoveToElement(productThisItem);
            action.Perform();
            ClickProductThisItem();
            //productThisItem.Click();
            WaitForElementToBeVisible(By.CssSelector("#fbtCheck-1"), 60);
            ClickBtnAddBothToBasket();
            ClickGoToBasket();
            //btnAddBothToBasket.Click();
            //WaitForElementToBeVisible(By.CssSelector("input[name='submit.addToCart']"), 10);
            return this;
        }

        // scroll down and click HomeGardenPets
        public HomePage ClickHomeGardenPets()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(deptHomeGardenPets);
            action.Perform();
            deptHomeGardenPets.Click();
            //WaitForElementToBeVisible(By.CssSelector("ul.hmenu.hmenu-visible > li:nth-child(20)"), 10);
            return this;
        }

        // scroll down and click on PetSupplies
        public HomePage ClickPetSupplies()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(petSupplies);
            action.Perform();
            petSupplies.Click();
            //WaitForElementToBeVisible(By.CssSelector("ul.hmenu.hmenu-visible.hmenu-translateX > li:nth-child(27)"), 10);
            return this;
        }

        // sideMenuDeptDogs
        public HomePage ClickSideMenuDeptDogs()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(sideMenuDeptDogs);
            action.Perform();
            sideMenuDeptDogs.Click();
            return this;
        }

        // sideMenuDogsTreats
        public HomePage ClickSideMenuDogsTreats()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(sideMenuDogsTreats);
            action.Perform();
            sideMenuDogsTreats.Click();
            return this;
        }

        // select Pedigree food brand checkbox from left hand side menu
        public HomePage ClickSideMenuFeaturedBrandPedigree()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(sideMenuFeaturedBrandPedigree);
            action.Perform();
            sideMenuFeaturedBrandPedigree.Click();
            return this;
        }

        // click featured category 'Dogs' jpeg
        public HomePage ClickDogsCategory()
        {
            WaitForElementToBeVisible(By.CssSelector(".a-list-item"), 60);
            Actions action = new Actions(Driver);
            action.MoveToElement(categoryDogsJpeg);
            action.Perform();
            categoryDogsJpeg.Click();
            return this;
        }

        // hover over Dry Food
        public HomePage HoverFoodDry()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(dryDogFood);
            action.Perform();
            Thread.Sleep(1000);
            return this;
        }

        // click Food jpeg
        public HomePage ClickDogTreatsJpeg()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(dogTreatsJpeg);
            action.Perform();
            dogTreatsJpeg.Click();
            //WaitForElementToBeVisible(By.CssSelector("[title='Treats']"), 10);
            return this;
        }

        // select Pedigree food brand checkbox from left hand side menu
        public HomePage SelectFoodBrandPedigreeCheckbox()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(checkboxBrandPedigree);
            action.Perform();
            checkboxBrandPedigree.Click();
            //WaitForElementToBeVisible(By.CssSelector("#p_89\\/Pedigree > span > a > div > label > i"), 10);
            return this;
        }

        // select item weight 1 to 1.9kg
        public HomePage SelectItemWeight1To1_9Kg()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(itemWeight1To1_9Kg);
            action.Perform();
            itemWeight1To1_9Kg.Click();
            //WaitForElementToBeVisible(By.CssSelector("#p_n_feature_two_browse-bin\\/42254101031"), 10);
            return this;
        }

        // select container type Tub
        public HomePage SelectTubContainer()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(containerTypeTub);
            action.Perform();
            containerTypeTub.Click();
            //WaitForElementToBeVisible(By.CssSelector("[aria-label='Tub'] .a-icon"), 10);
            return this;
        }

        // select Dental Sticks from side menu
        public HomePage ClickDentalSticksJpeg()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(dentalSticksJpeg);
            action.Perform();
            dentalSticksJpeg.Click();
            //WaitForElementToBeVisible(By.CssSelector("[title='Dental Sticks']"), 10);
            return this;
        }

        // select product DentaStix
        public HomePage ClickDentaStix()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(prodPedigreeDentaStix);
            action.Perform();
            prodPedigreeDentaStix.Click();
            //WaitForElementToBeVisible(By.CssSelector("Medium Dog, 112 Sticks - 2.88 kg megapack"), 10);
            return this;
        }

        // select either carat or radio button then add to basket
        public HomePage ClickAddToBasket()
        {
            if (btnOneTimePurchase.Displayed)
            {
                btnOneTimePurchase.Click();
            }
            else if (caratOneTimePurchase.Displayed)
            {
                caratOneTimePurchase.Click();
            }
            else if (paneOneTimePurchase.Displayed)
            {
                paneOneTimePurchase.Click();
            }

            Actions action = new Actions(Driver);
            action.MoveToElement(btnAddToBasket);
            action.Perform();
            btnAddToBasket.Click();
            //WaitForElementToBeVisible(By.CssSelector("#add-to-cart-button"), 10);
            return this;
        }

        // select toolbar basket
        public HomePage ClickToolbarBasket()
        {
            WaitForElementToBeVisible(By.CssSelector("#nav-cart-count"), 60);
            Actions action = new Actions(Driver);
            action.MoveToElement(toolbarBasket);
            action.Perform();
            toolbarBasket.Click();
            return this;
        }

        // change Quantity dropdown
        public HomePage ChangeQtyToFour()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(dropdownQtyBasket);
            action.Perform();
            //WaitForElementToBeVisible(By.CssSelector("span[class='a-button-text a-declarative']"), 60);
            dropdownQtyBasket.Click();
            //WaitForElementToBeVisible(By.CssSelector("#quantity_4"), 60);
            dropdownQty4.Click();
            Thread.Sleep(1000);
            return this;
        }

        // select Product from basket
        public HomePage ClickShoppingBasketProduct()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(shoppingBasketProduct);
            action.Perform();
            shoppingBasketProduct.Click();
            //WaitForElementToBeVisible(By.CssSelector("span[class='a-truncate-full']"), 10);
            return this;
        }

        // switch to new browser tab
        public HomePage SwitchNewTab()
        {
            string originalWindowHandle = Driver.CurrentWindowHandle;

            // Get a list of all open tabs
            var handles = Driver.WindowHandles;

            // Switch to the desired tab
            foreach (string handle in handles)
            {
                if (!handle.Equals(originalWindowHandle))
                {
                    Driver.SwitchTo().Window(handle);
                    // Code to perform actions on the desired tab
                    break;
                }
            }
            return this;
        }

        // page down once - simulates a page down action
        public HomePage PageDown()
        {
            Actions actions = new Actions(Driver);
            actions.SendKeys(Keys.PageDown).Build().Perform();
            return this;
        }

        // page down twice - simulates a page down action
        public HomePage PageDownTwice()
        {
            Actions actions = new Actions(Driver);
            actions.SendKeys(Keys.PageDown).SendKeys(Keys.PageDown).Build().Perform();
            return this;
        }

        // uncheck This item
        public HomePage ClickProductThisItem()
        {
            Thread.Sleep(3000);

            Actions action = new Actions(Driver);
            //action.ScrollToElement(productThisItem);
            action.MoveToElement(productThisItem);
            action.Perform();
            productThisItem.Click();
            WaitForElementToBeVisible(By.CssSelector("#fbtCheck-1"), 10);
            return this;
        }

        // select add both to basket
        public HomePage ClickBtnAddBothToBasket()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(btnAddBothToBasket);
            action.Perform();
            btnAddBothToBasket.Click();
            Thread.Sleep(1000);
            //WaitForElementToBeVisible(By.CssSelector("input[name='submit.addToCart']"), 10);
            return this;
        }


        // select Go to basket - btnGoToBasket - ("//*[@id=\'sw-gtc\']")
        public HomePage ClickGoToBasket() 
        {
            WaitForElementToBeVisible(By.XPath("//*[@id=\'sw-gtc\']"), 60);
            Actions action = new Actions(Driver);
            action.MoveToElement(btnGoToBasket);
            action.Perform();
            btnGoToBasket.Click();
            Thread.Sleep(1000);
            return this;
        }
    }
}
