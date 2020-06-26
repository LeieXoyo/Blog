from orator.migrations import Migration


class CreateMusicsTable(Migration):

    def up(self):
        """
        Run the migrations.
        """
        with self.schema.create('musics') as table:
            table.increments('id')
            table.string('name').nullable()
            table.string('author').nullable()
            table.string('cover_url').nullable()
            table.string('file_url').nullable()
            table.timestamps()

    def down(self):
        """
        Revert the migrations.
        """
        self.schema.drop('musics')
