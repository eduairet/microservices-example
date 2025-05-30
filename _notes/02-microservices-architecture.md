# Microservices Architecture

- Modular simple API
- It appeared in 2011 and consolidated in 2014 because of [Martin Fowler's article](https://martinfowler.com/articles/microservices.html).

## Componentization via Services

- Components are services that can be independently deployed and managed.
- All the components create the software system.
- Modularity can be achieved through:
  - Libraries called directly within the process.
  - Services that communicate over a network (Web APIs, RPC, etc.).
    - In microservices we prefer using services.
    - This will allow us to deploy and scale each component independently.
    - It will force us to create an interface for each service.

## Organizing Around Business Capabilities

- Microservices are organized around business capabilities.
- Each capability is a service that can be developed, deployed, and scaled independently by a different team without affecting the rest of the system.
  - This allows teams to work in parallel and reduces dependencies, leading to a quicker development cycle.
  - The project boundaries will be easier to define since each service is focused on a specific business capability.

## Products not Projects

- With microservices the focus is to deliver working products that can be deployed and used by customers.
- This means that the teams are responsible for the entire lifecycle of the service, from development to deployment and maintenance.
- This approach encourages teams to have a close relationship with the customers and to be responsive to their needs.
  - It increases customer satisfaction and reduces the time to market.
  - Changes the developer mindset from just focusing on writing code to also considering what's the business value of the code they write.

## Small Endpoints and Dumb Pipes

- Dumb pipes means simpler communication protocols.
- It encourages to use already existing protocols like HTTP, REST, and JSON.
  - It accelerates the development process since developers can use existing libraries and tools.
  - Makes it easier to integrate, maintain, and scale the system.

## Decentralized Governance

- Microservices allow teams to choose the best tools and technologies for their services.
- Each team makes their own decisions about the technology stack, programming languages, and frameworks they use, this also means that each team is fully responsible for the service they create.
- This approach allows teams to be more agile and to adapt quickly to changes in the business requirements.
- Since each team selects their own tools, a microservices system tends to be Polyglot, meaning that it can use multiple programming languages and technologies.
  - This is very useful to leverage the strengths of each technology and to use the best tool for the job.

## Decentralized Data Management

- Each service has its own database.
- This is the most controversial aspect of microservices and it's not always possible to implement because it can lead to data duplication and consistency issues.
- However, it allows teams to have more control over their data and to choose the best database technology for their service.

## Infrastructure Automation

- A microservices system requires to be fully automated for testing, deployment, and scaling.
- This means that the infrastructure should be treated as code, and the deployment process should be automated using tools like:
  - Docker, Kubernetes, or Terraform.
  - Continuous Integration and Continuous Deployment (CI/CD) pipelines like Jenkins, GitLab CI, or GitHub Actions.

## Design for Failure

- Since microservices are distributed systems, they are more prone to failures, in fact a lot can go wrong.
- Monitoring and logging are an essential part of this type of architecture to make it easier to detect and fix issues.

## Evolutionary Design

- Moving to microservices is a gradual process.
- It is not necessary to rewrite the entire system from scratch, instead, you can start by identifying the most critical components and refactoring them into microservices.

## Conclusion

- These are the main principles of microservices architecture and are just intended to be guidelines not strict rules.
- Some of the must to have principles are:
  - Componentization via services.
  - Organizing around business capabilities.
  - Decentralized governance.
  - Decentralized data management (when possible).
  - Infrastructure automation.
