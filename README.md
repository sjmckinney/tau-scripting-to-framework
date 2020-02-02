# tau-scripting-to-framework
Based on Test Automation University course "From Scripting to Framework with Selenium and C#" but using the RoyaleApi site rather than the StatsRoyale site as recent changes to the site seemed to break the code base as published to Github.

## Framework structure and seperation of concerns

The use of a logical structure to organise a test framework, adopting patterns and best practices, aids maintainability and reduces the time required for new comers to be able to to add new tests, extend it and trace and fix faults.

This framework consists of one solution and three projects that begin the seperation the framework into a number of concerns in keeping with [SOLID](https://en.wikipedia.org/wiki/SOLID) principles.

* Framework
* Royale
* Royale.Tests

Framework contains the code for driver creation and management, Royale contains the page object models and Royale.Tests contains the tests. Within the projects other directory structures can be used to logically seperate code into further defined concerns i.e. Models and Services in the Framework project.

### Models and Services

Model here is defined in the sense of archetype and each card class has the responsibility of holding the cards attributes. The Models directory contains details of each card as individually named classes. Each card inherits from the ```BaseCard``` class which defines a cards attributes as virtual properties which are overriden by the child classes to contain the actual values.

The Services directory contains the ```InMemoryCardService```. This class has the responsibility of retrieving the appropriate card class as an instance of the parent ```BaseCard``` when provided with the cards name. This instance is used in the tests in order to provide the expected values which the test asserts against.

The ```InMemoryCardService``` class implements the ```ICardService``` interface. Any card service class that implements this interface can be configured to be used by the framework at run time so allowing for card details to come from static class files, a database or any other source.

## Making use of NUnit features

Test runners, like NUnit, simplify the execution and organisation of tests and the reporting of test results.

* Seperation of tests and data
* Parallelisation

## dotnet commandline reference

[dotnet restore](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore?tabs=netcore2x)

Restores the dependencies and tools of a project.

[dotnet clean](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-clean) && [dotnet build](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build)

Clean and build the project

[dotnet test](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test?tabs=netcore21) `--filter testcategory=cards`

.NET test driver used to execute unit tests with added filter clause

[Link to markdown cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet)