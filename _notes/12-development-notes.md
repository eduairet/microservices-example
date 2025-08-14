# Development Notes

- When we're dockerizing a microservice project, we need to avoid HTTPS in the `projectLaunchSettings.json` file. This is because Docker containers typically do not handle HTTPS directly, and it can complicate the setup unnecessarily. Instead, we should focus on HTTP for local development within Docker.

## RabbitMQ

- RabbitMQ is a robust messaging broker that can be used to facilitate communication between microservices. It supports various messaging patterns and provides features like message queuing, routing, and delivery guarantees.
- The service bus needs to be configured to use RabbitMQ as the transport layer. This involves setting up the connection string and ensuring that the RabbitMQ server is running and accessible from the microservices.
  - It should be fault-tolerant, meaning that if the RabbitMQ server is down or unreachable, the microservices should handle this gracefully without crashing.
- To set it up, we can use Docker to run a RabbitMQ instance locally. This can be done by adding a [RabbitMQ service](../AsciiTypeGenerator/docker-compose.yml) to our `docker-compose.yml` file, specifying the image and necessary ports for communication and management.
  - Once it's set up and running visit `http://localhost:15672` or the port you exposed for the service and log in with the default credentials (username: `guest`, password: `guest`).
  - When logged in, you can create exchanges, queues, and bindings as needed for your microservices to communicate effectively, the `Exchanges` tab and the `Queues` tab are most likely the ones you'll be using the most.

## MassTransit

- MassTransit is a popular .NET library for building message-based applications. It provides a high-level abstraction over messaging systems like RabbitMQ, making it easier to implement messaging patterns and handle message routing, serialization, and error handling.
- The main advantage of using MassTransit is that it simplifies the development and scaling of microservices by providing a consistent and easy-to-use API for messaging that can switch between different transport layers (like RabbitMQ, Azure Service Bus, etc.) with minimal code changes.

## ACID transactions

- ACID transactions are a set of properties that guarantee that database transactions are processed reliably. The acronym stands for Atomicity, Consistency, Isolation, and Durability.
- In the context of microservices, ensuring ACID compliance can be challenging due to the distributed nature of the architecture. However, it is crucial for maintaining data integrity and consistency across services.
- To implement ACID transactions in a microservices environment using MassTransit, we can implement an outbox with retry. This involves storing messages that need to be sent to other services in a database table (the outbox) as part of the same transaction that modifies the local data. Once the transaction is committed, a background process can read the outbox and send the messages to the message broker (e.g., RabbitMQ). This ensures that either both the data change and the message send succeed or fail together, maintaining ACID properties.
