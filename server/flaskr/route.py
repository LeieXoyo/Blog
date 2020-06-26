from models import Article, Image, Music

def init_app(app):

    @app.route('/hello')
    def hello():
        return 'Hello, World!'

    @app.route('/test')
    def test():
        return f'Result: {Article.all().first().author}'
        