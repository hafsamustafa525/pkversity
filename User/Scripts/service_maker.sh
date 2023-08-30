#!/bin/bash 

  
app_name=$1 

code_path=$2 

port=$3 

service_file=/etc/systemd/system/$app_name.service 
  

touch $service_file 
  

echo "[Unit]"  > $service_file  

echo "Description=Service for .NET application "$app_name" " >> $service_file  

echo "[Service]" >> $service_file  

echo "WorkingDirectory="$code_path"" >> $service_file  

echo "ExecStart=/usr/bin/dotnet "$code_path""$app_name".dll" >> $service_file  

echo "Restart=always" >> $service_file  

echo "RestartSec=10 # Restart service after 10 seconds if dotnet service crashes" >> $service_file  

echo "Environment=ASPNETCORE_ENVIRONMENT=Production" >> $service_file  

echo "Environment=DOTNET_PRINT_TELEMETRY_MESSAGE=false" >> $service_file  

echo "Environment=ASPNETCORE_URLS=http://0.0.0.0:"$port"" >> $service_file  

echo "[Install]" >> $service_file  

echo "WantedBy=multi-user.target" >> $service_file  


sudo systemctl enable "$app_name" 

sudo systemctl daemon-reload 

sudo systemctl start "$app_name".service 