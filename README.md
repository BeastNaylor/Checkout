# Price Basket Solution
## Brief
The brief for this project was to create a program which could accept a list of items and return the total cost, minus any special offers that are being held.
> PriceBasket Milk Beans Bread

The format for this should be as follows:
> Subtotal: £2.00
> Beans 10% off: -50p
> Total: £1.50

In the situation where there are no special offers available, it should print the following:
> Subtotal: £2.00
> (No offers available)
> Total: £1.50

## Further Development
In order to reduce the edits required to the codebase in the future, the Products and SpecialOffer loaders could be changed to read from a local file, or make an API call to receive their relevant information
