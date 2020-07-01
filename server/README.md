# server

## 项目构建请求
```
Python: ^3.8
Poetry: https://python-poetry.org/
```

### 使用Poetry安装项目依赖
```
poetry install
```

### 使用Orator初始化数据库
```
进入虚拟环境: poetry shell
创建Sqlite文件: orator migrate:install
运行迁移: orator migrate
```

### 部署服务端
```
使用虚拟环境中已有的Gunicorn部署: gunicorn -w 4 -b 127.0.0.1:5000 "flaskr:create_app()"
or 选择其他喜欢的方式部署flaskr项目.
```
