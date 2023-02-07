# BogStandardSelenium
Basic Selenium Page Object Model for a renowned e-commerce website written in C#

3 tests whereby the same product (Pedigree DentaStix) is selected by:

  1) By Brand - from 'Pet Supplies' then the icons 'Dogs/Dog Treats/Brand/Products', filtering on the brand 'Pedigree'
  2) By Type - from 'Pet Supplies' then left hand menu 'Dogs/Treats/Brand/Products' filtering on the brand 'Pedigree'
  3) By Search - from the global search box, searching the whole website for 'dog dental sticks' selecting 'Pedigree DentaStix' from the search results 

In all cases above, using separate C# methods (making the test steps easy to follow), the quantity of 1 packet of DentaStix is added to the basket.

An assertion is made on the contents, quantity and price of the basket.

The second part of the test consists of using the same steps increasingb the quantity from 1 to 4 and adding an additional 2 items to the basket.

In the first test (By Brand), all indivdual test steps are listed enabling newcomers to follow the test steps.

The second and third tests use generic methods encapsulating these test steps into 2 separate methods (EditBasket, CompletePurchase) thereby reducing the repetition of code.

A final assertion is made on the quantity and product names in the cart.
