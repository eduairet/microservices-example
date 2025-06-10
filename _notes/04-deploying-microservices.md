# Deploying Microservices

- Deploying microservices must be an automated process.
- If deployment is very cumbersome, slow or complex, the whole system will fail.
- The deployment is not executed by the architect, but by the operations team.

## Continuous Integration (CI) and Continuous Delivery/Deployment (CD)

- CI/CD is a set of practices that enable development teams to deliver code changes more frequently and reliably.
- The phases of CI/CD are:
  - **Integration:**
    - **Build:** The code is compiled and packaged.
    - **Unit Tests:** Automated tests are run to verify the functionality of individual components.
    - **Integration Tests:** Tests are run to verify the interaction between components.
  - **Delivery/Deployment:**
    - **Staging:** The application is deployed to a staging environment that mimics production.
    - **Production:** The application is deployed to the production environment.
- CI/CD pipelines:
  - Automate the process of building, testing, and deploying applications, making them faster to deliver, more reliable, and well documented by the pipeline's reports.
  - Define the steps to be executed in the CI/CD process, including build, test, and deployment stages.
  - Usually use YAML or JSON files to define the pipeline configuration.
- The paper of the architect in the CI/CD process consists of:
  - Make sure that the CI/CD pipeline is well defined and documented.
  - Help to shape the steps of the pipeline.

## Containers

- Containers are a lightweight way to package and run applications.
- They provide a consistent environment for applications to run, regardless of the underlying infrastructure.
- They can be copied between machines and run on any platform that supports the container runtime.
  - In fact this is the main difference between containers and virtual machines, virtual machines use a hypervisor to run the operating system and applications, while containers share the host operating system kernel.
- Why containers?
  - Predictable and consistent environment (no more "it works on my machine" issues).
  - Performance: Containers are lightweight and have less overhead than virtual machines.
  - Density: Multiple containers can run on a single host, making better use of resources.
- Why not containers?
  - They're not isolated like virtual machines, so if one container has a security vulnerability, it can affect other containers on the same host.

## Docker

- Docker is a platform for developing, shipping, and running applications in containers.
- This is the way Docker works:
  - Client: The Docker client is the primary way to interact with Docker. It can communicate with the Docker daemon to build, run, and manage containers.
  - Docker Host: The Docker host is the machine where Docker is installed. It runs the Docker daemon, which is responsible for managing images and containers.
    - Docker images are the blueprints for containers. They contain everything needed to run an application, including the code, runtime, libraries, and dependencies.
    - A container is an image that's build and run
  - Registry: The Docker registry is a repository for Docker images. It can be public (like Docker Hub) or private.
- Containers are created in different ways, the most common are:
  - **Dockerfile:** A text file that contains instructions for building a Docker image. It defines the base image, the application code, and any dependencies.
  - **Docker Compose:** A tool for defining and running multi-container Docker applications. It uses a YAML file to define the services, networks, and volumes needed for the application.
  - The most popular cloud providers (AWS, Azure, GCP) have their own container services that can be used to deploy and manage containers.
  -
- The most popular container orchestration tool is Kubernetes.
  - Kubernetes is an open-source platform for automating the deployment, scaling, and management of containerized applications.
  - It provides features like load balancing, service discovery, and self-healing.
  - Kubernetes uses a declarative approach to define the desired state of the application and automatically manages the deployment to achieve that state.
