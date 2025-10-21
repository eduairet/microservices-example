# Microservices

This repository contains resources and notes related to microservices architecture, created for educational purposes by Eduardo Aire Torres.

## Notes

1. [Introduction to Microservices](./_notes/01-introduction-to-microservices.md)
2. [Microservices Architecture](./_notes/02-microservices-architecture.md)
3. [Designing Microservices Architecture](./_notes/03-designing-microservices-architecture.md)
4. [Deploying Microservices](./_notes/04-deploying-microservices.md)
5. [Testing Microservices](./_notes/05-testing-microservices.md)
6. [Service Mesh](./_notes/06-service-mesh.md)
7. [Logging and Monitoring](./_notes/07-logging-and-monitoring.md)
8. [When not to use Microservices](./_notes/08-when-not-to-use-microservices.md)
9. [Microservices and the Organization](./_notes/09-microservices-and-the-organization.md)
10. [Anti-Patterns and Common Mistakes](./_notes/10-anti-patterns-and-common-mistakes.md)
11. [Breaking Monoliths into Microservices](./_notes/11-breaking-monoliths-into-microservices.md)
12. [Development Notes](./_notes/12-development-notes.md)

## Containerization and Deployment

- In the root of the project (`AsciiTypeGenerator`), run the following commands to build the Docker images for the different services and push them to Docker Hub:

  - Build and push Docker images for the services:

    - Ascii Service:

      ```bash
      docker build --no-cache -f AsciiService/Dockerfile -t ${DOCKER_USERNAME}/ascii-service:latest .
      docker push ${DOCKER_USERNAME}/ascii-service:latest
      ```

    - Gateway Service:

      ```bash
      docker build --no-cache -f GatewayService/Dockerfile -t ${DOCKER_USERNAME}/gateway-service:latest .
      docker push ${DOCKER_USERNAME}/gateway-service:latest
      ```

    - Identity Service:

      ```bash
      docker build --no-cache -f IdentityService/Dockerfile -t ${DOCKER_USERNAME}/identity-service:latest .
      docker push ${DOCKER_USERNAME}/identity-service:latest
      ```

    - Search Service:
      ```bash
      docker build --no-cache -f SearchService/Dockerfile -t ${DOCKER_USERNAME}/search-service:latest .
      docker push ${DOCKER_USERNAME}/search-service:latest
      ```

- Run the containers using Docker Compose:
  ```bash
  docker-compose up -d
  ```

### References

- [Microservices Architecture - The Complete Guide](https://www.udemy.com/course/microservices-architecture-the-complete-guide/)
- [Build a Microservices app with .Net and NextJS from scratch](https://www.udemy.com/course/build-a-microservices-app-with-dotnet-and-nextjs-from-scratch/)
