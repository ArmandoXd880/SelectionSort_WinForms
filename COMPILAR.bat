@echo off
setlocal
cd /d "%~dp0"
set "selectionCompiler=%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\csc.exe"
if not exist "%selectionCompiler%" set "selectionCompiler=%WINDIR%\Microsoft.NET\Framework\v4.0.30319\csc.exe"
if not exist "%selectionCompiler%" (
  echo No se encontro el compilador. Abre SelectionSort_WinForms.sln en Visual Studio.
  pause
  exit /b 1
)
if not exist bin mkdir bin
"%selectionCompiler%" /nologo /target:winexe /out:bin\SelectionSortDemo.exe /reference:System.dll /reference:System.Core.dll /reference:System.Drawing.dll /reference:System.Windows.Forms.dll Program.cs MainForm.cs SelectionEngine.cs
if errorlevel 1 (
  echo No se pudo compilar. Revisa los errores anteriores.
  pause
  exit /b 1
)
copy /y App.config bin\SelectionSortDemo.exe.config >nul
echo Listo. Abre bin\SelectionSortDemo.exe
pause
