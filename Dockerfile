FROM microsoft/dotnet:2.2.104-sdk AS build-env
WORKDIR /app

# copy everything else and build
COPY . ./
RUN dotnet test ./NSBSagaTest.Tests/NSBSagaTest.Tests.csproj