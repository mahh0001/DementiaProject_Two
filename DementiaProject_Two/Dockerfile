#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 59500
EXPOSE 44318

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY ["DementiaProject_Two/DementiaProject_Two.csproj", "DementiaProject_Two/"]
RUN dotnet restore "DementiaProject_Two/DementiaProject_Two.csproj"
COPY . .
WORKDIR "/src/DementiaProject_Two"
RUN dotnet build "DementiaProject_Two.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DementiaProject_Two.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DementiaProject_Two.dll"]