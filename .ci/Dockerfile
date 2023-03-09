FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine
WORKDIR /app
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
COPY buildOutput /app

ENV ASPNETCORE_URLS http://*:80
EXPOSE 80

ENTRYPOINT ["dotnet", "Givt.Backend.Bff.Retool.Service.dll"]