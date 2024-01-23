# ServerApp_UnitTest Tests

This repository contains unit tests for the ServerApp project. The tests cover key functionalities of the `DataBaseHandler` class and other related components.

## Table of Contents

- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installing](#installing)
- [Running the Tests](#running-the-tests)
- [Test Descriptions](#test-descriptions)
- [Built With](#built-with)
- [License](#license)
- [Output](#Output)

## Getting Started

These instructions will help you set up and run the unit tests for the ServerApp project.

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Microsoft.Data.SqlClient NuGet package](https://www.nuget.org/packages/Microsoft.Data.SqlClient)

### Installing

1. Clone this repository:

``bash
git clone https://github.com/yourusername/your-repo.git

2. Navigate to the ServerApp.Tests folder:

``bash
cd ServerApp_UnitTest

3. Running the Tests

Run the tests using the following command:

``bash
dotnet test

## Test Descriptions

- TestStartServer_SuccessfulConnection: Tests the startServer method in the Server class, simulating a successful client connection.

- TestSaveOrUpdateData: Tests the saveOrUpdateData method in the DataBaseHandler class by inserting data into a test database and verifying the inserted value


## Built With

- C#
- MSTest
- Microsoft.Data.SqlClient


## License

This project is licensed under the CCtech License.


## Output

![NoServer](https://github.com/Coderanildangi/Dashboard-PC-Usage-Unit-Test/assets/149321466/7445b61e-543f-468d-abb6-f382d27bd011)

![ServerYes](https://github.com/Coderanildangi/Dashboard-PC-Usage-Unit-Test/assets/149321466/8fbfc37c-283f-48b7-8534-9d359a40cbbb)

![ServerAllPass](https://github.com/Coderanildangi/Dashboard-PC-Usage-Unit-Test/assets/149321466/8f714419-b21f-40f8-918f-eaf997990928)

![ServerDatabaseFail](https://github.com/Coderanildangi/Dashboard-PC-Usage-Unit-Test/assets/149321466/2f84f662-b01e-40e9-9f1c-999d845ee475)




