For testing coverture of test with coverlet. Make sure to have coverlet msbuil, collector and console.

## To install coverlet conole globally
```  dotnet tool install --global coverlet.console --version 6.0.0 ```

## Test everything in the specific namespace
```  dotnet test /p:CollectCoverage=true /p:Include="[*].StringManipulation.*" ``` 

## Test everything in exluding classes or methods using [ExcludeFromCodeCoverage]
```  dotnet test /p:CollectCoverage=true /p:ExcludeByAttribute="ExcludeFromCodeCoverage" /p:CoverletOutputFormat=cobertura; ```

## Install nuget reportgenerator and go to Test Project
dotnet tool install --global dotnet-reportgenerator-globaltool --version 5.1.24
``` reportgenerator "-reports:coverage.cobertura.xml" "-targetdir:coverage-report" --reporttypes=html;```

## INstall 