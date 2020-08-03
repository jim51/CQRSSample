FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/BooksStore.API/BookStoreApi.csproj", "src/BooksStore.API/"]
COPY ["src/BooksStoreAPI.Application/BooksStoreAPI.Application.csproj", "src/BooksStoreAPI.Application/"]
COPY ["src/BooksStoreAPI.Models/BooksStoreAPI.Models.csproj", "src/BooksStoreAPI.Models/"]
COPY ["src/BookStoreAPI.Infrastructure/BookStoreAPI.Infrastructure.csproj", "src/BookStoreAPI.Infrastructure/"]
RUN dotnet restore "src/BooksStore.API/BookStoreApi.csproj"
COPY . .
WORKDIR "/src/src/BooksStore.API"
RUN dotnet build "BookStoreApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookStoreApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookStoreApi.dll"]
