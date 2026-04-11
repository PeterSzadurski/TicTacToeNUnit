FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

WORKDIR /src

COPY Solution.sln .

# copy projects first
COPY TicTacConsole/TicTacConsole.csproj TicTacConsole/
COPY TicTacToeLogic/TicTacToeLogic.csproj TicTacToeLogic/
COPY TicTacUnitTest/TicTacUnitTest.csproj TicTacUnitTest/


# nuget packages
RUN dotnet restore

# The rest of the source code
COPY . .

RUN dotnet publish TicTacConsole/TicTacConsole.csproj -c Release -o /app/publish

# runtime

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final

WORKDIR /app

#copy published
COPY --from=build /app/publish .

# commands
ENTRYPOINT [ "dotnet", "TicTacConsole.dll" ]