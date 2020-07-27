FROM mcr.microsoft.com/mssql/server
ENV SA_PASSWORD ControleSocial@
ENV ACCEPT_EULA Y
EXPOSE 1433
ENTRYPOINT ["/opt/mssql/bin/sqlservr"]