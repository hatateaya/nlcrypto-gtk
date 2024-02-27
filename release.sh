#!/bin/bash
dotnet publish -c Release -r osx-x64 -p:PublishSingleFile=true -p:PublishTrimmed=true
dotnet publish -c Release -r win-x64 -p:PublishSingleFile=true -p:PublishTrimmed=true
dotnet publish -c Release -r linux-x64 -p:PublishSingleFile=true -p:PublishTrimmed=true
