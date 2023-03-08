FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
ARG GITHUB_TOKEN

WORKDIR /app

# Copy everything
COPY ./ ./

RUN dotnet nuget add source --username MaikelStuivenberg --password $GITHUB_TOKEN --store-password-in-clear-text --name github "https://nuget.pkg.github.com/givtnl/index.json"

RUN dotnet restore

RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine
WORKDIR /app
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
COPY --from=build-env /app/out .

ENV ASPNETCORE_URLS http://*:80
EXPOSE 80

ENTRYPOINT ["dotnet", "Givt.Backend.Bff.Retool.Service.dll"]