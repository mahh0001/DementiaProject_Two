FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 50541
EXPOSE 44375

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY MatchmakingService/MatchmakingService.csproj MatchmakingService/
RUN dotnet restore MatchmakingService/MatchmakingService.csproj
COPY . .
WORKDIR /src/MatchmakingService
RUN dotnet build MatchmakingService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MatchmakingService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MatchmakingService.dll"]
