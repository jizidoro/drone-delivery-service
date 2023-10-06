# Use the official .NET 6 SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /src

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build-env /src/out .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "DroneDelivery.API.dll"]