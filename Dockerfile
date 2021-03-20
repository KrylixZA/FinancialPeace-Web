FROM mcr.microsoft.com/dotnet/sdk:5.0 as build
WORKDIR /src
COPY /src .
RUN dotnet publish ./FinancialPeace.Web/FinancialPeace.Web.csproj --configuration Release --output /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0 as app
EXPOSE 50000
ENV ASPNETCORE_URLS=http://*:50000
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT [ "dotnet", "FinancialPeace.Web.dll" ]