# N5 Backend Challenge

N5 Backend Challenge for user permissions with CQRS, Kafka, ElasticSearch

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- Docker and Docker Compose installed.
- SQL Server Management Studio (SSMS) if you want to connect to the database directly.

### Building and Running the Project

1. Navigate to the root directory of the project where `docker-compose.yml` is located.

2. Build the Docker images:

```bash
docker-compose build
```

Then

```bash
docker-compose up
```

### Accessing the Database

Before running the initial script, you'll need to log in to SQL Server Management Studio (SSMS) with the following credentials:

- **Server**: `localhost`
- **Username**: `sa`
- **Password**: `My!Password1234`


### Testing the API

Once the services are up and running, you can access the Swagger UI to test the API endpoints at:

[http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html)

## Authors

- David Robles
