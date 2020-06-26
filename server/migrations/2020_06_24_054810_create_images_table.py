from orator.migrations import Migration


class CreateImagesTable(Migration):

    def up(self):
        """
        Run the migrations.
        """
        with self.schema.create('images') as table:
            table.increments('id')
            table.string('img_url').nullable()
            table.timestamps()

    def down(self):
        """
        Revert the migrations.
        """
        self.schema.drop('images')
