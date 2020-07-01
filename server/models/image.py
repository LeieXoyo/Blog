from flaskr.db import Model
import pendulum


class Image(Model):
    def fresh_timestamp(self):
        return pendulum.now()
