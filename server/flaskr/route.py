from flask import jsonify

from models import Article, Game, Image, Music

def init_app(app):

    @app.route('/hello')
    def hello():
        return 'Hello, World!'

    @app.route('/api/games', methods=['GET'])
    def get_games():
        return jsonify(Game.all().serialize())
    
    @app.route('/api/images', methods=['GET'])
    def get_images():
        return jsonify(Image.all().serialize())
        