FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-image
 
WORKDIR /home/app

COPY ./*.sln ./
COPY ./*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done
 
RUN dotnet restore

COPY . .
 
RUN dotnet publish ./Api/Api.csproj -o /publish/
 
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime

WORKDIR /publish

COPY --from=build-image /publish .
 
ENTRYPOINT ["dotnet", "Api.dll"]