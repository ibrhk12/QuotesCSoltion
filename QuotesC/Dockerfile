FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["QuotesC/QuotesC.csproj", "QuotesC/"]
COPY ["BusinessLayer/BusinessLayer.csproj", "BusinessLayer/"]
COPY ["DataAccessLayer/DataAccessLayer.csproj", "DataAccessLayer/"]
RUN dotnet restore "QuotesC/QuotesC.csproj"
COPY . .
WORKDIR "/src/QuotesC"
RUN dotnet build "QuotesC.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "QuotesC.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "QuotesC.dll"]