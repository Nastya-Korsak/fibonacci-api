# Fibonacci-Api
REST API that computes and returns the nth number in the Fibonacci sequence.
The application can be run in several ways. Below you can find instruction how to run it locally and by docker-compose file.

## Prerequisites
* [.NET SDK](https://dotnet.microsoft.com/en-us/download) - to run locally 
* [Docker](https://www.docker.com/) (for running with Docker) - to run in docker

## How to Run the Application
Before launching, please clone the application on your local computer.

### Running Locally
1) Open application folder in terminale
2) Restore the dependencies
```
dotnet restore
```
3) Build the project
```
dotnet build
```
4) Run the application:
```
dotnet run --project src/FibonacciApi/FibonacciApi.csproj
```
5) By default application should be run on http://localhost:5050/
- Swagger API: http://localhost:5050/swagger/index.html
- Health Check: http://localhost:5000/hc

### Running with Docker
1) Make sure that docker is running
2) Open the application folder in terminale
3) Run the application:
```
docker-compose up 
```
4) Application should be avalible on http://localhost:8080/
- API: http://localhost:8080/swagger/index.html
- Health Check: http://localhost:8080/hc

## How to Run Unit Tests
1) Open application folder in terminale
2) Run tests:
```
dotnet test
```

## Operational Considerations
To create a detailed plan for deploying and running this service in a production environment, it's important to first gather information about the infrastructure and services that will be used. This includes factors like the chosen cloud provider (e.g., AWS, Azure) and any existing CI/CD pipelines.

### Containerization
To simplify deployment proccess, service can be deployed using Docker, Docker image will add consistency between development, testing, and production environments. Docker file was added for application, so you can alredy try to use it f.e. with docker-compose command described above.

### CI/CD
CI/CD pipeline is a great way to automate building, testing, and deploying the service, and speed up deployment process. 
For setuping CI/CD pipeline can be used different tools and platforms. F.e. like Jenkins, GitLab CI, Azure Devops and others. For automatic infrastructure managment Terraform can be used.

The pipeline should include:
- Build the Docker image/application. Triggered automatically on pushed to the main branch.
- Run unit tests to prevent breaking changes before deployment.
- Quality control. SonarQube can be used as code quality analyzes to check for code smells to prevent bugs.
- Automated deployment. On this steps happens preparation of enviroment for deploy(f.e infrastructure setup) and deploy of pushed code.
Code is deployed ti staging environment for further testing and approval, and after approval to production.

### Monitoring and Logging
The monitoring/logging strategies can vary depends on infrastructure. But generally can be used next approch:
- Collecting logs in centralized logging service to simplify debugging. F.e. Azure Monitor, AWS CloudWatch, also great tool is DataDog.
- Monitoring health of application by health check endpoint. It can be automatically checked in AWS and Azure and other services.
- Monitor performance metrics (e.g., response times, CPU/memory usage), this metrics can be collected in AWS, Azure, DataDog and others.
- Setup alert on critical events based on monitorings.

### Service scaling to handle a high number of requests
Before scaling, it's essential to understand where the service is experiencing bottlenecks. Identify: CPU, Memory usage; Response times; Network load; Database performance.
And make decision depends on this information. For small application as Fibonacci-Api I belive the preferable way is Horizontal Scaling:
1) Increes number of instances of application.
2) Add load balancer to distribute incoming traffic.
3) Consider Multi-region deployment for lower latency for users in different geographic locations.
4) Consider Rate Limiting, to restrict the number of requests a client can make over a certain time.
5) Set up auto-scaling rules to reduce costs.
6) Also would be greate to perform load testing for testing finale solution.

