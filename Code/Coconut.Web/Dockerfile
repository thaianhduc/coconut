# Custom image based on aspnetcore to host a web application
FROM         microsoft/aspnetcore
MAINTAINER   Thai Anh Duc
COPY         . /app
WORKDIR      /app
ENTRYPOINT   ["dotnet", "Coconut.Web.dll"]
