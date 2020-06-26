import os

from flask import Flask

def create_app(test_config=None):
    app = Flask(__name__)

    from . import db, route
    db.init_app(app)
    route.init_app(app)
    return app
