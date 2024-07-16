#!/bin/sh
#currentDate=`date +%-m%d`
#imageVersion=0.6.$currentDate-alpine
. ./get-version.sh

echo Building mytelegram/mytelegram-sms-sender:$imageVersion
docker build -t mytelegram/mytelegram-sms-sender -f ./Dockerfile-sms-sender ../../source
docker tag mytelegram/mytelegram-sms-sender mytelegram/mytelegram-sms-sender:$imageVersion