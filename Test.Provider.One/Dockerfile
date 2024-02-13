#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Test.Provider.One/Test.Provider.One.csproj", "Test.Provider.One/"]
RUN dotnet restore "Test.Provider.One/Test.Provider.One.csproj"
COPY . .
WORKDIR "/src/TestTask.SearchService"
RUN dotnet build "Test.Provider.One.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Test.Provider.One.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Test.Provider.One.dll"]