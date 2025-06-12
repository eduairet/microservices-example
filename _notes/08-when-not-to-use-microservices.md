## When not to use Microservices

- **Small Systems:** If the system is small and simple, using microservices can add unnecessary complexity.
  - Rule of thumb, if the system just needs two or three services, it's better to use a monolithic architecture.
- **Intermingled Functionality or Data:** If the functionality or data is tightly coupled, microservices can complicate the architecture.
  - For example, if a service needs to access data from another service frequently, it might be better to keep them together.
- **Performance sensitive services:** If the system has performance-sensitive services that require low latency, microservices can introduce overhead.
  - The communication between services can add latency, so if the system requires high performance, a monolithic architecture might be a better choice.
- **Quick and Dirty Prototypes:** If the system is a quick prototype or proof of concept, using microservices can slow down the development process.
  - In this case, it's better to use a monolithic architecture to quickly iterate and test ideas.
- **Not planed updates:** If the system is not planned to be updated frequently, using microservices can add unnecessary complexity.
  - If the system is stable and doesn't require frequent updates, a monolithic architecture might be a better choice.
