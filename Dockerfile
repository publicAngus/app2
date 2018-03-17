FROM microsoft/dotnet
WORKDIR /app

COPY $pwd/bin/Debug/netcoreapp2.0/publish /app

EXPOSE 5000/tcp

ENTRYPOINT [ "dotnet","app2.dll","--urls=http://localhost:5000" ]