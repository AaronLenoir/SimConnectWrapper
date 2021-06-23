

function Print-Variables {
	param ($variables)
	
	Foreach ($variable in $variables) {
		$dotNetName = ((Get-Culture).TextInfo).ToTitleCase($variable.Name.ToLower()).Replace(' ', "")
		
		$simConnectDataType = "SIMCONNECT_DATATYPE.UNKNOWN"
		if ($variable.Unit -eq "Bool" -or 
			$variable.Unit -eq "Number" -or
			$variable.Unit -eq "Enum") {
			$simConnectDataType = "SIMCONNECT_DATATYPE.INT32"
		} elseif ($variable.Unit -eq "Knots" -or
				  $variable.Unit -eq "Feet" -or
				  $variable.Unit -eq "Radians" -or
				  $variable.Unit -eq "Degrees") {
			$simConnectDataType = "SIMCONNECT_DATATYPE.FLOAT32"
		}

		Write-Host "/// <summary>"
		Write-Host "/// $($variable.Description) ($($variable.Unit.ToLower()))"
		Write-Host "/// </summary>"
		Write-Host "public static SimConnectProperty $($dotNetName) = new SimConnectProperty("
		Write-Host "    SimConnectPropertyKey.$($dotNetName), ""$($variable.Name)"", ""$($variable.Unit.ToLower())"", $($simConnectDataType));"
	}

	Foreach ($variable in $variables) {
		$dotNetName = ((Get-Culture).TextInfo).ToTitleCase($variable.Name.ToLower()).Replace(' ', "")
		
		Write-Host "simConnectWrapper.Subscribe(SimConnectProperties.$($dotNetName));"
	}
}

$variables = Import-Csv -Delimiter ";" -Path .\aircraft-autopilot-variables.csv

#Print-Variables($variables);

$variables = Import-Csv -Delimiter ";" -Path .\aircraft-avionics-variables.csv

Print-Variables($variables);