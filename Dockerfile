FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src

COPY ./src ./
#WORKDIR /src/RevisionVR.DataAccess

#RUN dotnet ef migrations add InitialCreate
#RUN database-update

WORKDIR /src/RevisionVR.WebApi

RUN dotnet restore

RUN dotnet publish -c Release -o output

#RUN dotnet ef database update

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS serve
WORKDIR /app
COPY --from=build /src/RevisionVR.WebApi/output .

EXPOSE 80
EXPOSE 443

ENTRYPOINT [ "dotnet", "RevisionVR.WebApi.dll" ]
#CMD ["dotnet", "ef", "database", "update"]