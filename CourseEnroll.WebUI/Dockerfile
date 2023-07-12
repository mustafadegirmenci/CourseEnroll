FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CourseEnroll.WebUI/CourseEnroll.WebUI.csproj", "CourseEnroll.WebUI/"]
RUN dotnet restore "CourseEnroll.WebUI/CourseEnroll.WebUI.csproj"
COPY . .
WORKDIR "/src/CourseEnroll.WebUI"
RUN dotnet build "CourseEnroll.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CourseEnroll.WebUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourseEnroll.WebUI.dll"]
