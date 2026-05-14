FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["FIAP.Hackathon.OES.Worker/FIAP.Hackathon.OES.Worker.csproj", "FIAP.Hackathon.OES.Worker/"]
RUN dotnet restore "FIAP.Hackathon.OES.Worker/FIAP.Hackathon.OES.Worker.csproj"

COPY . .
RUN dotnet publish "FIAP.Hackathon.OES.Worker/FIAP.Hackathon.OES.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "FIAP.Hackathon.OES.Worker.dll"]