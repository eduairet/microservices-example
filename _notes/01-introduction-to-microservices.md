# Introduction to Microservices

- It's the most popular architecture in the world for building large-scale applications.
- It allows for the development of applications as a collection of loosely coupled services.
- Even though it's widely used, it can be complex and challenging to implement effectively, and it will not be the best fit for every project.

## History of Microservices

- Before microservices there were only two main architectures: monolithic and SOA (Service-Oriented Architecture).
- **Monolithic Architecture**: An application is built as a single, unified unit. All components are tightly coupled, making it difficult to scale and maintain.
  - It is easier to develop and deploy initially, but as the application grows, it becomes harder to manage.
  - It shares a single codebase and resources, which can lead to bottlenecks.
- **SOA**: Introduced the concept of services, but often used heavy protocols and was more complex than necessary. It was not as flexible as microservices.
  - It used protocols like SOAP and WSDL, which added complexity and were the reason for its decline.
  - The services were often designed around business functions communicating with each other through a central Enterprise Service Bus (ESB).
  - It allowed modularity and technology agnosticism that allowed different teams to work on different services.

## Problems with Monolithic and SOA Architectures

- **Monolithic Architecture**:
  - It forces you to use the same technology stack for the entire application.
  - Scaling is difficult because you have to scale the entire application, not just the parts that need it.
  - Deployment is complex because any change requires redeploying the entire application.
    - It always needs to be redeployed, even for small changes.
    - It can lead to long deployment times and increased risk of downtime.
    - Forces testing of the entire application every time a change is made.
    - It leads to longer development cycles and slower time to market.
  - Inefficient resource utilization because all components share the same resources.
    - CPU, memory, and storage are shared, disallowing us to optimize resource usage per component.
  - Large and complex codebase that is hard to understand and maintain.
    - Testing is difficult because it won't always catch all bugs
    - Every little change can become a nightmare and can potentially make the entire application obsolete.
- **SOA**:

  - The ESB (Enterprise Service Bus) is often a single point of failure.
    - It can become a bottleneck for performance and scalability, besides of expensive
    - It tries to do everything, which leads to complexity and performance issues or completely fails.
  - It's effective only when short development cycles are needed.

    - There are no tools to test and deploy services independently.
    - It needs to be tested manually, which makes all the time saved in development useless.

    ## Conclusion

    - Microservices architecture addresses the limitations of monolithic and SOA architectures by allowing for independent development, deployment, and scaling of services.
