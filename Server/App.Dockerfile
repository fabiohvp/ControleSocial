FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster
COPY src/ControleSocial.Api/bin/Debug/netcoreapp3.1 /app
WORKDIR /app
EXPOSE 8999
#EXPOSE 443
ENTRYPOINT ["dotnet", "ControleSocial.Api.dll"]

#docker network create -d bridge localdev