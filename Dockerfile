FROM mcr.microsoft.com/dotnet/sdk:5.0 as build
WORKDIR /src
COPY /src .
RUN dotnet publish ./FinancialPeace.Web.sln --configuration Release --output /app

FROM nginx:alpine
EXPOSE 80
COPY --from=build /app/wwwroot /usr/share/nginx/html