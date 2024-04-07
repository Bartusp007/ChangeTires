## Architectural assumptions.

### Overview
The application domain is a tire change service.

### Assumptions

1. Architectural style : Rest Api, Monolithic Architecture (as the application grows, we can consider separating microservices)

2. The core of the application will be the domain. We will create applications based on Domain Driving Design.

3. Queries and commands should be separated using the CQRS pattern, this will allow us to effectively use the DDD Aggregate pattern to ensure transactional changes in the domain state.

4. For persistence purposes, a relational database should be created, preferably MS SQL Server.

5. ORM : Entity Framework

6. We will use the MediatoR library for communication with Commands, Query and events. This will allow us, when expanding the application, to add additional piplines for logging information about Commandami, Query and events

