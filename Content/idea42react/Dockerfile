FROM microsoft/dotnet:2.0-sdk AS build-env

WORKDIR /app

RUN curl -sL https://deb.nodesource.com/setup_8.x |  bash
RUN apt-get install -y nodejs
RUN curl -o- -L https://yarnpkg.com/install.sh | bash -s -- --version 1.7.0
ENV PATH="$PATH:/root/.yarn/bin"

# copy csproj and restore as distinct layers
COPY *.csproj ./

# copy and build everything else
COPY . ./

# build steps
RUN yarn cache clean
RUN yarn
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/out/ ./
COPY --from=build-env /app/wwwroot ./wwwroot

EXPOSE 3000

ENTRYPOINT ["dotnet", "WebApplicationBasic.dll"]

