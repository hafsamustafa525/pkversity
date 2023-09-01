#!/bin/bash

sudo systemctl stop User.service

sudo systemctl disable User

sudo systemctl daemon-reload

