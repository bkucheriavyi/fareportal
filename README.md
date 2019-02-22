[![Build Status](https://bkucheriavyi.visualstudio.com/Ultimate%20Game/_apis/build/status/bkucheriavyi.fareportal?branchName=master)](https://bkucheriavyi.visualstudio.com/Ultimate%20Game/_build/latest?definitionId=7&branchName=master)

# fareportal
Cosole application that will calculate the cost of a beverage with additives. 

###How to run application
```
cd FPT.Console/
dotnet run 
```
###How to run tests (from root derictory)
```
dotnet run
```
#### List available tests:
```
dotnet run -t
```
####Output :
```
The following Tests are available:
    CloseOrder_CallculuatesTotal
    GetAdditives_ReturnsAdditivesListByIds
    GetBeverages_ReturnsBeveragesListByIds
    CreateOrder_MultipleTimes_ReturnsOrderWithIncrementedId
    CreateOrder_ReturnsOrderWithNewId
    GetAdditives_AdditivesStringIsNotValid_Throws("")
    GetAdditives_AdditivesStringIsNotValid_Throws(null)
    GetAdditives_AdditivesStringIsNotValid_Throws("blabla")
    GetAdditives_AdditivesStringIsNotValid_Throws("2|3|3")
    GetAdditives_AdditivesStringIsNotValid_Throws("not a number or array")
    GetAdditives_BeverageIsCompatible_ReturnsAdditive
    GetAdditives_BeverageIsNotCompatible_Throws
    GetAdditives_ManyOrDuplicated_ReturnsManyOrDuplicativeAdditives
    GetBeverage_IdWasNotAnIntegerValue_Throws("")
    GetBeverage_IdWasNotAnIntegerValue_Throws(null)
    GetBeverage_IdWasNotAnIntegerValue_Throws("not and integer for sure")
    GetBeverage_NoBeverageFound_Throws
    GetBeverage_ReturnsBeverage
    Register_ThrowsOnIdDuplication
    Run_CallsSingleRegisteredAction_Once
    Run_InputIdWasOutOfTheRange_NoActionCalls(-1)
    Run_InputIdWasOutOfTheRange_NoActionCalls(0)
    Run_InputIdWasOutOfTheRange_NoActionCalls(int.MaxValue)
    Run_InputIdWasOutOfTheRange_NoActionCalls(int.MinValue)
    Run_InputWasntString_NoActionCalls("")
    Run_InputWasntString_NoActionCalls("still not and integer")
    Run_InputWasntString_NoActionCalls(null)
    Calculate_OrderContainsNoItems_ReturnsOrderWithTotalZero
    Calculate_ReturnsOrderWithTotalSet
    GetAdditives_Returns
    GetBeverages_Returns
```
####Default data set
```
Beverages:
1)Coffee - Id - 1; - Cost $15
2)Tea - Id - 2; - Cost $10

Additives only for coffee:
1) Chocolate topping - Id - 1; - Cost $2
2) Strawberry topping - Id - 1; - Cost $2

Additives for both tea and coffee:
1)Milk - Id - 3; - Cost $2
2)Sugar - Id - 4; - Cost $1
3)Cinnamon - Id - 5; - Cost $3
4)Lemon - Id - 6; - Cost $1
```

####Example:
```
Hello Joe, choose action and press enter when ready:
1. Create order
2. Modify opened order
3. List closed orders
4. Close all pending orders
1
Enter beverage:
1
Enter additives:
4,3,4,1
Cost: $21
```
