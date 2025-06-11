# Testing Microservices

- Testing microservices is very challenging due to their distributed nature.
- The most difficult part will be testing shared state between microservices and dependant services, especially when some of them are not under your control.

## Types of Tests

- **Unit Tests:**
  - Test individual components or functions in isolation.
  - It focus in-process only, without external dependencies.
  - There are several per method to cover edge cases.
  - They should not be affected by external factors like databases or network calls.
  - These are developed by the service team, and they are the first line of defense against bugs.
- **Integration Tests:**
  - Test the interaction between multiple components or services.
  - It ensures the service's functionality works correctly when integrated with other services or components.
  - We try to cover all the code paths in the service.
  - Sometimes we need to mock external dependencies, like databases or third-party services, and for this we use test doubles.
    - **Fakes:** Simulate the behavior of real components, allowing tests to run without needing the actual component.
    - **Stubs:** Provide predefined responses to specific calls, allowing tests to control the behavior of dependencies.
    - **Mocks:** Allow verification of interactions with dependencies, ensuring that the service calls them as expected without the need of the actual implementation or data.
  - These are usually developed by the QA team.
- **End-to-End Tests:**
  - Test the entire system from the user's perspective, ensuring all components work together as expected.
  - They simulate real user scenarios and validate the system's behavior in a production-like environment.
  - These tests are really difficult to maintain and run, as they require a lot of resources and time, that's why we just need to consider the most critical edge cases and not try to cover everything.

## Conclusion

- The most important tests in this architecture are Integration Tests, as they ensure the service's functionality.
