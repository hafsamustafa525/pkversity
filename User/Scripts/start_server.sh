#!bin/bash

sudo systemctl enable User 

sudo systemctl daemon-reload 

sudo systemctl start User.service 