# Designing Microservices Architecture

- Designing microservices architecture involves a lot of planning, it's not just about starting to code.
- Key considerations include:
  - **Domain-Driven Design (DDD):** Understand the business domain and model it effectively.
  - **Bounded Contexts:** Define clear boundaries for each microservice to avoid overlap and confusion.
  - **Service Granularity:** Determine the right size for each service, balancing between too coarse and too fine-grained.
  - **Data Management:** Decide how data will be managed across services, considering patterns like database per service or shared database.
  - **Communication:** Choose appropriate communication protocols (e.g., REST, gRPC, message brokers) based on service requirements.
  - **Deployment Strategy:** Plan how services will be deployed, considering containerization and orchestration tools like Docker and Kubernetes.
  - **Monitoring and Logging:** Implement robust monitoring and logging to track service health and performance.

## Mapping the Components

- This step ho the software will look like in the long run.
- It involves defining the components (services) of the whole system.
- Mapping should be based on:

  - **Business Requirements:** Understand the business needs and how they translate into services.
  - **Functional Autonomy:** Each service should be able to function independently, without other business requirements.
  - **Data Entities:** The service is designed around well-defined data entities. The entities can only be related within each other just by IDs.
  - **Data Autonomy:** The underlying is an atomic unit of data, meaning that the data does not depend on other services to function properly.

    - E-commerce platform example:

      |           | Business Requirements    | Functional Autonomy              | Data Entities               | Data Autonomy                                      |
      | --------- | ------------------------ | -------------------------------- | --------------------------- | -------------------------------------------------- |
      | Inventory | Manage products in stock | Add, remove, update, quantity    | Items                       | None                                               |
      | Orders    | Process customer orders  | Add, cancel, calculate sum       | Orders, Shipping, Address   | Related to items by ID, Related to customers by ID |
      | Customers | Manage customer data     | Add, update, delete, get account | Customers, Address, Contact | Related to orders by ID                            |
      | Payments  | Process payments         | Process payments                 | Payment History             | None                                               |

- When the services need to communicate we can follow three different approaches:

  - **Data Duplication:** Services can duplicate data to avoid direct dependencies, ensuring they remain autonomous.
  - **Service Query:** Services can query each other for data when necessary, allowing for real-time data access.
  - **Aggregation Service:** An aggregation service can be used to query the data externally and provide a unified view, reducing the need for direct service-to-service communication.

- Services are not intended to retrieve a lot of data, in case we need to handle large datasets, we can use a report engine to avoid the system to be overloaded.
- And the last thing to consider are the Cross-Cutting Services like logging, caching, user management, etc. These services are shared across multiple microservices and should be defined in a way that they can be reused without creating dependencies between the services.

## Defining Communication Patterns
