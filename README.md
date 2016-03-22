# run on local
```
mkdir data  
dnu restore  
dnx ef migrations add SqliteMigrations  
dnx ef database update  
dnx web  
```

# run on docker
```
git clone https://github.com/shchy/tips2.git
cd tips2
docker build -t tips2 .
mkdir /var/lib/sqlite
docker run -d -p 80:5000 -v /var/lib/sqlite:/app/data tips2
```

jenkins build test
