FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["./BlazorTourOfHeroes/BlazorTourOfHeroes.Server/BlazorTourOfHeroes.Server.csproj", "BlazorTourOfHeroes/BlazorTourOfHeroes.Server/"]
COPY ["./BlazorTourOfHeroes/BlazorTourOfHeroes.Client/BlazorTourOfHeroes.Client.csproj", "BlazorTourOfHeroes/BlazorTourOfHeroes.Client/"]
COPY ["./BlazorTourOfHeroes/BlazorTourOfHeroes.Shared/BlazorTourOfHeroes.Shared.csproj", "BlazorTourOfHeroes/BlazorTourOfHeroes.Shared/"]
RUN dotnet restore "BlazorTourOfHeroes/BlazorTourOfHeroes.Server/BlazorTourOfHeroes.Server.csproj"
COPY . .
WORKDIR "/src/BlazorTourOfHeroes/BlazorTourOfHeroes.Server"
RUN dotnet build "BlazorTourOfHeroes.Server.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BlazorTourOfHeroes.Server.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BlazorTourOfHeroes.Server.dll"]