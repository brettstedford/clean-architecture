FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /
COPY *.sln .
COPY src/Presentation/Presentation.csproj /src/Presentation/
COPY src/Domain/Domain.csproj /src/Domain/
COPY src/Application/Application.csproj /src/Application/
COPY src/Infrastructure/Infrastructure.csproj /src/Infrastructure/
RUN dotnet restore .

COPY src/ /src/
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/Presentation/Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Presentation.dll"]
