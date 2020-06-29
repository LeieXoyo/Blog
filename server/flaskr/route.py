from flask import jsonify

from models import Article, Game, Image, Music

def init_app(app):

    @app.route('/hello')
    def hello():
        return 'Hello, World!'

    @app.route('/api/articles', methods= ['GET'])
    def get_articles():
        return jsonify(Article.all().serialize())

    @app.route('/api/article', methods=['POST'])
    def post_article():
        pass

    @app.route('/api/article/<int:id>', methods=['PUT'])
    def update_article(id):
        pass

    @app.route('/api/article/<int:id>', methods=['DELETE'])
    def delete_article(id):
        pass

    @app.route('/api/games', methods=['GET'])
    def get_games():
        return jsonify(Game.all().serialize())
    
    @app.route('/api/images', methods=['GET'])
    def get_images():
        return jsonify(Image.all().serialize())
        
    @app.route('/api/musics', methods=['GET'])
    def get_musics():
        return jsonify(Music.all().serialize())