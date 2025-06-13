# Breaking Monoliths into Microservices

- Breaking a monolith into microservices is a good idea when we want to:
  - Shorten the update cycle.
  - Modularized the system.
  - Save costs.
    - Modern infrastructure is cheaper.
    - Legacy teams are often more expensive to maintain.
  - Modernize the system.
  - Being attractive.

## Strategies

### New Modules as Services

- New modules can be developed as microservices from the start.
- This allows for a gradual transition to a microservices architecture without affecting the existing monolith.
- Depending on the size of the monolith, this can never become a pure microservices architecture.

### Separate Existing Modules to Services

- Existing modules can be separated into microservices.
- This can be done by identifying the boundaries of each module and extracting them into separate services.
- This approach allows for a gradual transition to a full microservices architecture.

### Complete Rewrite

- A complete rewrite of the system can be done to create a microservices architecture.
- This is the most expensive option and should be avoided if possible.
- The most common case to take this approach is when the existing system is very old and difficult to maintain.
