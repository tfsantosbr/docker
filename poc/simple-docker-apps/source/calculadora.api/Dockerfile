# Build Stage
FROM microsoft/aspnetcore-build:2 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o /publish

# Runtime Stage
FROM microsoft/aspnetcore:2
WORKDIR /app
COPY --from=build-env /publish ./
ENTRYPOINT ["dotnet", "calculadora.api.dll"]