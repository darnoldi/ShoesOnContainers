FROM microsoft/aspnetcore-build:2.0.0 AS build

WORKDIR /code

COPY . .

RUN dotnet restore

RUN dotnet publish --output /out/ --configuration Release

	FROM microsoft/asnetcore:2.0.0

	COPY --from=build /out /app/

	WORKDIR /app

	ENTRYPOINT ["dotnet","ProductCatalogAPI.dll"]

