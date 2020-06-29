from orator.migrations import Migration


class CreateGamesTable(Migration):

    def up(self):
        """
        Run the migrations.
        """
        with self.schema.create('games') as table:
            table.increments('id')
            table.string('name').nullable()
            table.string('img_url').nullable()
            table.string('html_url').nullable()
            table.timestamps()

    def down(self):
        """
        Revert the migrations.
        """
        self.schema.drop('games')
