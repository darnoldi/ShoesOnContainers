FROM microsoft/aspnetcore:2.0
COPY dist /app
WORKDIR /app
EXPOSE 80/tcp
ENTRYPOINT ["dotnet","ProductCatalogAPI.dll"]
