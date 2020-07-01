from flaskr.db import Model
import pendulum


class Game(Model):
    def fresh_timestamp(self):
        return pendulum.now()
