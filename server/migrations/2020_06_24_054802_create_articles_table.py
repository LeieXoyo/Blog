from orator.migrations import Migration


class CreateArticlesTable(Migration):

    def up(self):
        """
        Run the migrations.
        """
        with self.schema.create('articles') as table:
            table.increments('id')
            table.string('title')
            table.string('author')
            table.string('author_ip').nullable()
            table.string('content')
            table.boolean('delete_flag').default(False)
            table.timestamps()

    def down(self):
        """
        Revert the migrations.
        """
        self.schema.drop('articles')
