from flaskr.db import Model
import pendulum


class Music(Model):
    def fresh_timestamp(self):
        return pendulum.now()
