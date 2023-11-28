FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy all csproj files and restore as distinct layers
COPY *.sln . 
COPY */*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done
RUN dotnet restore

# Copy everything else
COPY . .

# Building Api
RUN dotnet build "EmployeeManagement.Api/EmployeeManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeeManagement.Api/EmployeeManagement.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeManagement.Api.dll"]