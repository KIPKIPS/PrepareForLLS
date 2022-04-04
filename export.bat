@echo off
SET root=%~dp0
SET suffix="ExportConfig\ExportConfig\bin\Debug\netcoreapp3.1"
cd %root%%suffix% 
start ExportConfig.exe %~dp0
exit