FROM microsoft/dotnet:2.0-sdk AS build-env

WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./

# copy and build everything else
COPY . ./

# build steps
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/out/ ./

EXPOSE 80

ENTRYPOINT ["dotnet", "WebApplicationBasic.dll"]

