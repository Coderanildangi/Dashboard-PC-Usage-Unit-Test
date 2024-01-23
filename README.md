# Dashboard-PC-Usage-Unit-Test

This document provides information about unit tests for the components in the Dashboard PC Usage project. Unit tests are essential for verifying that individual components behave as expected in isolation.

## Project Structure

The project is divided into three main components:

1. **Client App (ClientApp):**
   - The Client App is responsible for collecting system data from individual PCs within the network.

2. **Server App (ServerApp):**
   - The Server App acts as a central server, handling incoming data from multiple clients and storing it in a database.

3. **Dashboard Monitor App (DashboardApp):**
   - The Dashboard Monitor App visualizes aggregated PC usage data received from the server app.

## Unit Tests Structure

The unit tests are structured using the NUnit testing framework, and they are located in separate test projects corresponding to each component:

1. **Client App Tests (ClientAppTests):**
   - Test methods covering functionalities such as connecting to the server and collecting data.

2. **Server App Tests (ServerAppTests):**
   - Test methods for starting and stopping the server, handling client connections, and storing data in the database.

3. **Dashboard Monitor App Tests (DashboardAppTests):**
   - Test methods for connecting to the server and visualizing data on the dashboard.

## Running the Tests

Follow these steps to run the unit tests:

1. **Open the Solution:**
   - Open the solution in your preferred C# IDE.

2. **Build the Solution:**
   - Build the solution to ensure that all necessary dependencies are resolved.

3. **Run Tests:**
   - Use the testing framework's test runner (e.g., NUnit Test Explorer) to discover and run the tests.

4. **Verify Results:**
   - Ensure that all tests pass, indicating that individual components behave as expected.

## Additional Notes

- **Mocking:**
  - Consider using mocking frameworks (e.g., Moq) for more complex scenarios where external dependencies need to be simulated in unit tests.

- **Test Coverage:**
  - Aim to achieve high test coverage, ensuring that critical functionalities are thoroughly tested.

- **Continuous Integration:**
  - Integrate unit tests into your continuous integration (CI) pipeline to run them automatically on each code commit.

## Contributing

Contributions to the unit tests are welcome! Fork the repository, add new tests or improve existing ones, and submit a pull request.

## License

This project's unit tests are under the same [CCtech](LICENSE) as the main project.

