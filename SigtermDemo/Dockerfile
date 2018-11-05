FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["SigtermDemo/SigtermDemo.csproj", "SigtermDemo/"]
RUN dotnet restore "SigtermDemo/SigtermDemo.csproj"
COPY . .
WORKDIR "/src/SigtermDemo"
RUN dotnet build "SigtermDemo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SigtermDemo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SigtermDemo.dll"]