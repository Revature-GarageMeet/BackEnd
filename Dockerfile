
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app


COPY . .

# We restore and build our application
RUN dotnet clean Project-3-back-end.sln
RUN dotnet publish WebAPI --configuration Release -o ./publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS run

WORKDIR /app/publish
COPY --from=build /app/publish .


# When user runs our image in their container, execute dotnet WebAPI.dll
CMD ["dotnet", "WebAPI.dll"]