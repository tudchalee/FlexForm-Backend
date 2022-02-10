FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FlexForm-Backend/FlexForm-Backend.csproj", "FlexForm-Backend/"]
RUN dotnet restore "FlexForm-Backend/FlexForm-Backend.csproj"
COPY . .
WORKDIR "/src/FlexForm-Backend"
RUN dotnet build "FlexForm-Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FlexForm-Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FlexForm-Backend.dll"]
