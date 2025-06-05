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

- Efficient communication between microservices is crucial for system performance and reliability.
- The main patterns for communication are:

  - **1-to-1 Synchronous Communication:**
    - Services communicate directly with each other in real-time (thread blocking).
    - Suitable for scenarios where immediate response is required.
    - This approach can lead to tight coupling and potential bottlenecks, it's recommended to implement a gateway to handle the services interactions.
    - Example: RESTful APIs, gRPC.
  - **1-to-1 Asynchronous Communication:**
    - Services communicate with each other without waiting for a response (non-blocking, fire and forget).
    - It's useful when we need to send messages between services and the responsibility of processing the message is on the receiver.
    - It usually involves a message broker or queue to handle the messages.
  - **Publish-Subscribe or Event-Driven Communication:**
    - A service notifies other services about events without expecting a response.
    - It does not track the notification receivers and does not know anything about them.
    - This pattern is commonly implemented using message brokers like RabbitMQ, Kafka, or AWS SNS.

- Choosing the wrong communication pattern can lead to performance issues, and it's almost impossible to change it later.

## Selecting Technology Stack

- This architecture allows to select the most suitable technology stack for each service based on its requirements.
- There is no right or wrong technology stack, everything will depend on each necessity.
- The stack should be chosen based on hard evidence, not just personal preferences.
- Backend technologies:

  | Technology  | App Types                | Typed Language | Cross Platform | Community  | Performance      | Learning Curve |
  | ----------- | ------------------------ | -------------- | -------------- | ---------- | ---------------- | -------------- |
  | Node.js     | APIs, Web, Microservices | No (JS/TS)     | Yes            | Very Large | High (I/O bound) | Easy/Moderate  |
  | Spring Boot | APIs, Web, Microservices | Yes (Java)     | Yes            | Large      | High             | Moderate       |
  | .NET Core   | APIs, Web, Microservices | Yes (C#)       | Yes            | Large      | High             | Moderate       |
  | Django      | APIs, Web                | No (Python)    | Yes            | Large      | Moderate         | Easy           |
  | Go (Golang) | APIs, Microservices      | Yes            | Yes            | Growing    | Very High        | Moderate       |

- Storage:
  - **Relational Databases:**
    - Stores data in structured tables with relationships.
    - Examples: PostgreSQL, MySQL, SQL Server.
    - This is a good choice for services that require complex queries and structured data.
  - **NoSQL Databases:**
    - Stores data in a flexible, schema-less format.
    - Examples: MongoDB, Cassandra, Redis.
    - This is a good choice for services that require high scalability and flexibility in data storage.
  - **Cache:**
    - Used to store frequently accessed data for faster retrieval.
    - It stores only serialized data, which can be deserialized when needed.
    - Examples: Redis, Memcached.
    - This is a good choice for services that require high performance and low latency.
  - **Object Storage:**
    - Used to store large files and unstructured data.
    - Examples: AWS S3, Google Cloud Storage, Azure Blob Storage.
    - This is a good choice for services that require high availability and durability of data.

## Design the Architecture

- It is not different from software architecture.
- It's based in the layers paradigm, where each layer has a specific responsibility.
  - Layers represent a horizontal functionality of the components.
    ```
    Save / Retrieve Data -> Execute Logic -> Expose User Interface / API
    ```
- It forces the design of well-defined interfaces between the layers, which is a good practice.
- It's modular, meaning that each layer can be developed and tested independently.