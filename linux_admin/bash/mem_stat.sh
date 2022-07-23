DAY=$(date +"%d")
MONTH=$(date +"%m")
YEAR=$(date +"%y")
#sudo mkdir -p /var/log/mem_stats/$YEAR/$MONTH
#sudo touch /var/log/mem_stats/$YEAR/$MONTH/$DAY.log

SUM=0
NUM=0
PIDS=$(ps -eo pid)
echo $PID
readarray -t tableau < <(ps -eo pid)

for p in $(ps -eo pid)
#for p in "${tableau}"
do
echo "$p"
#PID=
#SUM = $((SUM + $(ps -o vsz= -p $PID)))
#((NUM++))
done
#echo $SUM/$NUM
