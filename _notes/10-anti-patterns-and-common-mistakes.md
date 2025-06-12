# Anti-Patterns and Common Mistakes

- Microservices require a thorough design and planning phase to avoid common pitfalls.
- They're not `Fire-and-Forget` solutions; they need ongoing management and maintenance.

## Common Anti-Patterns

- **No Well-Defined Services:**
  - Most of this errors happen in the mapping stage of the system, a negligence in this stage can result in bloated services.
  - This will also increase the dependency between services, ending up with a monolith.
- **No Well-Defined API:**
  - Services should have a clear and well-defined API, if not, no one will use it.
  - It should be consistent and easy to understand.
  - It should also be versioned to avoid breaking changes.
  - It should be platform agnostic, so it can be used by any client (just serialized data).
  - It must be part of the system design, not an afterthought.
- **Implementing Cross-Cutting Last:**
  - Cross-cutting services provide common functionality across services, such as logging, monitoring, and security.
  - They should be implemented early in the design phase, not as an afterthought.
- **Expanding Service Boundaries:**
  - Services should have well-defined boundaries, if not, they will end up being too large and complex.
  - Every service should have a single responsibility and should not be responsible for multiple things and extend on the road.
  - Think twice before adding new functionality to a service, if the functionality already exists in another service, it should be reused.
