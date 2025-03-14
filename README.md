# RiraProject

This project was developed upon request by Rira Company and provides basic CRUD operations for user management. It utilizes Docker for containerization and supports Protocol Buffers (Protobuf) and gRPC for endpoint communication.

Architecture
The project follows the Clean Architecture principles, ensuring a modular and maintainable structure.

Logging
The project uses Serilog integrated with Datadog for efficient log management and monitoring.

Initially, my preferred choice for the logging system was Elasticsearch due to its powerful search and analytics capabilities. However, since I didn't have sufficient expertise in it at the time, I opted for alternative logging solutions to ensure stability and maintainability.

Date Handling
In the Person entity, the system supports Shamsi (Persian) date format for birthdate input. However, it is stored in Gregorian format in the database. A validation mechanism ensures that the birthdate is entered in the following format:

📌 Example: "1374/03/12"
