FROM mcr.microsoft.com/dotnet/aspnet:7.0.13

WORKDIR /src

# Copia los archivos de la aplicación
COPY . .

EXPOSE 80

ENTRYPOINT ["dotnet", "WebApplication1.dll"]