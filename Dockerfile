#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 61851
EXPOSE 44322

FROM microsoft/dotnet:2.1-sdk-nanoserver-sac2016 AS build
WORKDIR /src
COPY ["testx/testx.csproj", "testx/"]
RUN dotnet restore "testx/testx.csproj"
COPY . .
WORKDIR "/src/testx"
RUN dotnet build "testx.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "testx.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "testx.dll"]