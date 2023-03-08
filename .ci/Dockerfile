FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy everything
COPY ./ ./

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