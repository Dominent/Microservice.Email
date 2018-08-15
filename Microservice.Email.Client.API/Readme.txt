docker login
heroku login
dotnet publish -c Release /property:PublishWithAspNetCoreTargetManifest=false // 2.0 only
docker build -t microservice-email-client-api ./bin/Release/netcoreapp2.0/publish
docker tag microservice-email-client-api registry.heroku.com/microservice-email-client-api/web
heroku container:login
docker push registry.heroku.com/microservice-email-client-api/web
heroku container:release web --app microservice-email-client-api
