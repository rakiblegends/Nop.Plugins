@echo off
set "PLUGIN_DIR=%~dp0"
set "TARGET_DIR=..\..\Presentation\Nop.Web\Plugins\Misc.SupplierList"

if not exist "%TARGET_DIR%" mkdir "%TARGET_DIR%"
 
xcopy /Y /S "%PLUGIN_DIR%plugin.json" "%TARGET_DIR%"
xcopy /Y /S "%PLUGIN_DIR%Views\*" "%TARGET_DIR%\Views\"
xcopy /Y /S "%PLUGIN_DIR%Controllers\*" "%TARGET_DIR%\Controllers\"
xcopy /Y /S "%PLUGIN_DIR%Services\*" "%TARGET_DIR%\Services\" 