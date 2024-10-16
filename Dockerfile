FROM mcr.microsoft.com/dotnet/sdk:8.0 as build-env
WORKDIR /src
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o /publish \
    --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
RUN adduser --disabled-password \
  --home /app \
  --gecos '' dotnetuser && chown -R dotnetuser /app
WORKDIR /src
COPY --from=build-env /publish .
USER dotnetuser

ENTRYPOINT dotnet FibonacciApi.dll