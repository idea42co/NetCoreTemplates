FROM microsoft/dotnet:2.0-sdk AS build-env

WORKDIR /app

RUN curl -sL https://deb.nodesource.com/setup_8.x |  bash
RUN apt-get install -y nodejs

# copy csproj and restore as distinct layers
COPY *.csproj ./

# copy and build everything else
COPY . ./

# build steps
RUN npm install -g gulp-cli
RUN npm install
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/out/ ./
COPY --from=build-env /app/wwwroot ./wwwroot
COPY --from=build-env /app/Views ./Views

EXPOSE 3000

ENTRYPOINT ["dotnet", "WebApplicationBasic.dll"]

