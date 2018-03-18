FROM microsoft/dotnet
WORKDIR /app

COPY $pwd/bin/Debug/netcoreapp2.0/publish /app

EXPOSE 5000

ENTRYPOINT [ "dotnet","app2.dll","--urls=http://*:5000" ]