# Logging and Monitoring

- **Logging:** Is recording the system's activities, errors, and events.
  - It's the best way to audit the system's behavior and diagnose issues.
  - It's also the best way to document the system's state and changes over time.
- **Monitoring:** Is the process of continuously observing the system's performance and health.
  - It's based in the system's metrics, which are quantitative measures of the system's performance.
  - It alerts the system's operators when something goes wrong or when the system is not performing as expected.

## Implementing Logging

- Logging should provide a wholistic view of the system's behavior.
- It should allow tracing end-to-end flow and as much information as possible.
- In microservices the logging should be a separate service and should be able to communicate with other services.
  - This will ensure the same logging format and structure across the system.
- It's usually structured with the following elements:
  - **Logging Library:** A library that provides the logging functionality.
    - It's recommended to use the same logging library across the system, but sometimes it's not possible and we may need to use different libraries for different services.
    - Use severity levels to classify the logs:
      - **Debug:** Detailed information, typically of interest only when diagnosing problems.
      - **Info:** Confirmation that things are working as expected.
      - **Warning:** An indication that something unexpected happened, or indicative of some problem in the near future.
      - **Error:** Due to a more serious problem, the software has not been able to perform some function.
      - **Critical:** A serious error, indicating that the program itself may be unable to continue running.
    - The information logged should be as detailed as possible and it's usually structured in this way:
      - **Timestamp:** The time when the log was generated.
      - **User:** The user who generated the log, if applicable.
      - **Severity:** The severity level of the log.
      - **Service Name:** The name of the service that generated the log.
      - **Message:** A human-readable message that describes the log.
      - **Stack Trace:** The stack trace of the error, if applicable.
      - **Correlation ID:** A unique identifier that allows tracing the log across different services.
  - **Transport:** A way to send the logs to a central location.
    - The most common transport solution is to use a message broker like Kafka or RabbitMQ.
    - Other options include using a database, a file, or a logging service like ELK (Elasticsearch, Logstash, Kibana) or Splunk.
  - **The service itself:** The service that generates the logs and saves them to the database.
    - It's preferred to use a service based on indexing / digesting / searching the logs.
    - The most common tools are the ELK stack (Elasticsearch, Logstash, Kibana) or Splunk.

## Implementing Monitoring

- Monitoring looks at metrics and detects anomalies in the system's performance, that's why it needs a simplified view of the system's status.
- It should provide alerts in a seamless way, so the operators can take action when something goes wrong.
- **Infrastructure Monitoring:** This is the process of monitoring the system's infrastructure, such as servers, databases, and networks.
  - It usually involves collecting metrics like CPU usage, memory usage, disk space, network traffic, etc.
  - Tools like Prometheus, Grafana, or Nagios are commonly used for infrastructure monitoring.
- **Application Monitoring:** This is the process of monitoring the system's applications, such as web servers, APIs, and microservices.
  - It usually involves collecting metrics like response time, error rate, request rate, etc.
  - Tools like New Relic, Datadog, or AppDynamics are commonly used for application monitoring.
