FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /src
COPY ["src/DMCIT.Web/DMCIT.Web.csproj", "src/DMCIT.Web/"]
RUN dotnet restore "src/DMCIT.Web/DMCIT.Web.csproj"
COPY . .
WORKDIR "/src/src/DMCIT.Web"
RUN dotnet build "DMCIT.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DMCIT.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DMCIT.Web.dll"]
