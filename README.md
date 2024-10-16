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
