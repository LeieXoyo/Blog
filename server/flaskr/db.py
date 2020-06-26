import os

import click
from flask.cli import with_appcontext
from orator import DatabaseManager, Model

db_file = 'flaskr.db'

config = {
    'sqlite': {
        'driver': 'sqlite',
        'database': db_file
    }
}

db = DatabaseManager(config)
Model.set_connection_resolver(db)

@click.command('create-db')
@with_appcontext
def create_db_command():
    if os.path.exists(db_file):
        click.echo("数据库已存在!")
    else:
        open(db_file, 'ab').close()
        click.echo("数据库已创建!")

def init_app(app):
    app.cli.add_command(create_db_command)
