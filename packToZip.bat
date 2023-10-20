@REM utf-8
chcp 65001

@REM Empty folder
del release\*.* /q
rd release\data /q
rd release\assests /q

@REM Copy necessary files
xcopy /e/c/y data\ release\data\
copy /y bin\Release\net6.0-windows\publish\win-x86\pokemon-bin-sorting-tool.exe release\pokemon-bin-sorting-tool.exe

@REM Copy ReadMe
xcopy /e/c/y assests\ release\assests\
copy /y ReadMe.md release\ReadMe.md

@REM Compress files
"C:\Program Files\7-Zip\7z.exe" a -t7z -r release\pokemon-bin-sorting-tool.7z release\*

@REM Clean folder
del release\*.exe /q
del release\data\*.* /q
rd release\data /q
del release\*.md /q
del release\assests\*.* /q
rd release\assests /q
