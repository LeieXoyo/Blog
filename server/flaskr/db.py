import os

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
