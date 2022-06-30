#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443

#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#COPY ["AddRestaurantAPI/AddRestaurantAPI.csproj", "AddRestaurantAPI/"]
#RUN dotnet restore "AddRestaurantAPI/AddRestaurantAPI.csproj"
#COPY . .
#WORKDIR "/src/AddRestaurantAPI"
#RUN dotnet build "AddRestaurantAPI.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "AddRestaurantAPI.csproj" -c Release -o /app/publish

#ROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "AddRestaurantAPI.dll"]



FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
 
 
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY AddRestaurantAPI.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /app
 
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app .
 
ENTRYPOINT ["dotnet", "AddRestaurantAPI.dll"]
