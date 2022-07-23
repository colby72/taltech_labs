sudo groupadd mem_stat_admins
for i in {1..30}
do
sudo useradd -m mem_admin$i
sudo usermod -a -G mem_stat_admins
done
