FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build_env
WORKDIR /app
COPY ./api/api.csproj .
RUN dotnet restore
COPY ./api/ .
RUN dotnet publish -c Release -o out

# create runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
EXPOSE 80
COPY --from=build_env /app/out .
ENTRYPOINT ["dotnet", "api.dll"]