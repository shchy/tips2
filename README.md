[![Circle CI](https://circleci.com/gh/shchy/tips2.svg?style=svg)](https://circleci.com/gh/shchy/tips2)

# run on local
```
mkdir data  
dnu restore  
dnx -p src/TipsWeb/project.json ef migrations add SqliteMigrations  
dnx -p src/TipsWeb/project.json ef database update  
dnx -p src/TipsWeb/project.json web  
```

# run on docker
```
git clone https://github.com/shchy/tips2.git
cd tips2
docker build -t tips2 .
mkdir /var/lib/sqlite
docker run -d -p 80:5000 -v /var/lib/sqlite:/app/data tips2
```
