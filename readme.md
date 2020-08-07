# Testing Azure Functions

This repo provides some examples for testing **Azure Functions**. The Function App contains two functions:

* An example **HTTP-triggered** function
* An example **Queue-triggered** function

I've provided 3 types of example tests:

1. Dependency injection container configuration tests
2. Integration testing Azure Functions
3. Unit testing Azure Functions

## Depedency injection container configuration tests

The [`ConfigurationTests.cs`](/FunctionApp.Tests/ConfigurationTests.cs) looks for Azure Functions in the source project for any Azure Functions and ensures they can be instantiated by the DI container. This tests that your DI container is properly configured.

This test doesn't actually exercise any run-time code, only Azure Function bootstrapping.

## Integration testing Azure Functions

These tests demostrate how to create an instance of an Azure Function whilst substituting one or more of its dependencies.

Using this technique, you can run an instance of your Azure Function as it will run at runtime. The DI container ensures the construction of the Azure Function and any of its dependencies as it would run at runtime. You have the option to substitute dependencies where necessary for a particular test.

Use this approach when you want to test how your components integrate with each other.

See [FunctionApp.Tests/Integration](/FunctionApp.Tests/Integration/) for examples.

## Unit testing Azure Functions

These tests demonstrate how to test an Azure Function unit in isolation from its dependencies.

The difference between this approach and the Integration approach, above, is that the Integration approach uses the DI container to create an instance whereas in the Unit approach, you must create an instance yourself. If the Unit has multiple dependencies then you must create all of those dependencies, too.

Use this approach when you want to test your Azure Function in isolation from other components.

See [FunctionApp.Tests/Unit](/FunctionApp.Tests/Unit/) for examples.
