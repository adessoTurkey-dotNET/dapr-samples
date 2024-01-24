$ScheduleServiceDapr = 'dapr.exe run --app-id scheduleservice --app-port 5001 --dapr-http-port 3501 --app-ssl --components-path .\dapr\components\ dotnet run -- --urls=https://localhost:7218/ -p ScheduleService/ScheduleService.csproj'
$ScheduleService= '--title "ScheduleService" -- pwsh.exe -Interactive -NoExit -Command ' + "$ScheduleServiceDapr"

$cmd = '-M -w -1 nt -d . ' + $ScheduleService

Start-Process wt $cmd
