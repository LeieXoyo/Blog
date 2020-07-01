from flaskr.db import Model
import pendulum


class Article(Model):
    def fresh_timestamp(self):
        return pendulum.now()
