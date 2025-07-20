
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src


COPY ["mealPlansAPI/mealPlansAPI.csproj", "mealPlansAPI/"]


COPY ["Services/Services.csproj", "Services/"]


COPY ["ApplicationDBContext/Repository.csproj", "ApplicationDBContext/"]


RUN dotnet restore "mealPlansAPI/mealPlansAPI.csproj"


COPY . .

WORKDIR "/src/mealPlansAPI"
RUN dotnet build "mealPlansAPI.csproj" -c Release -o /app/build


FROM build AS publish

RUN dotnet publish "mealPlansAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app


COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "mealPlansAPI.dll"]