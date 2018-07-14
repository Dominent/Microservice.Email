FROM microsoft/dotnet:2-runtime

WORKDIR /app

COPY . .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet Microservice.Email.Client.API.dll
