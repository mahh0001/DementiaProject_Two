FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 59500
EXPOSE 44318

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY DementiaProject_Two/DementiaProject_Two.csproj DementiaProject_Two/
RUN dotnet restore DementiaProject_Two/DementiaProject_Two.csproj
COPY . .
WORKDIR /src/DementiaProject_Two
RUN dotnet build DementiaProject_Two.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish DementiaProject_Two.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DementiaProject_Two.dll"]
