FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app
# Copy everything and build
COPY . ./
RUN dotnet restore "./SimpleSearch.Api.csproj"
RUN dotnet publish "SimpleSearch.Api.csproj" -c Release -o out
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SimpleSearch.Api.dll"]