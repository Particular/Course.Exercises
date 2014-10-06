param($installPath, $toolsPath, $package, $project)

write-host "NServiceBus.Interfaces has been deprecated an is no longer required" -foregroundcolor DarkRed 
write-host "Removing NServiceBus.Interfaces..." -foregroundcolor DarkRed 

uninstall-package NServiceBus.Interfaces -ProjectName $project.Name